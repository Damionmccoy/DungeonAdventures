using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DQGEventSystem {

    public class Damageable : MonoBehaviour
    {

        
        public List<string> CanBeHurtBy;
        public bool SendToPoolOnDeath = false;
        public bool DistroyOnDeath = false;
        public string PoolName;
        private string DamagerName;
        public int health;
        // Start is called before the first frame update
        void Start()
        {
            EventSystemManager.Instance.RegisterListener<UnitDamageEventInfo>(TakeDamage);
            EventSystemManager.Instance.RegisterListener<UnitDeathEventInfo>(Die);
            
        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                UnitDeathEventInfo deathInfo = new UnitDeathEventInfo();
                deathInfo.EventDescription = gameObject.name + " was killed by: " + DamagerName;
                deathInfo.UnitDead = this.gameObject;
                EventSystemManager.Instance.FireEvent(deathInfo);
            }

        }

        private void TakeDamage(EventInfo eventInfo)
        {

            UnitDamageEventInfo damageInfo = (UnitDamageEventInfo)eventInfo;
            if (CanBeHurtBy.Contains(damageInfo.DamagerName) && gameObject.name == damageInfo.UnitName)
            {
                health -= damageInfo.DamageAmount;
                DamagerName = damageInfo.DamagerName;
            }
        }

        void Die(EventInfo eventInfo)
        {
            UnitDeathEventInfo deathInfo = (UnitDeathEventInfo)eventInfo;

            if(deathInfo.UnitDead.name == gameObject.name)
            {
                if (!SendToPoolOnDeath && DistroyOnDeath)
                {
                    GameObject.Destroy(this.gameObject);
                }
                else if(SendToPoolOnDeath && !DistroyOnDeath && PoolName != "")
                {
                    //PoolManager.Instance.GetPool(PoolName).AddToPool(this.gameObject);
                }
            }
        }
    }
}
