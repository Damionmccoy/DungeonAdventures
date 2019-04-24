using UnityEngine;
using System.Collections;


namespace DQGEventSystem
{
    public class Damager : MonoBehaviour
    {
        public string DamagerName;
        public int DamageAmount;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            UnitDamageEventInfo damageInfo = new UnitDamageEventInfo();
            damageInfo.EventDescription = "Unit  " + gameObject.name + " has been hit";
            damageInfo.UnitName = collision.name;
            damageInfo.DamagerName = DamagerName;
            damageInfo.DamageAmount = DamageAmount;
           
            EventSystemManager.Instance.FireEvent(damageInfo);
        }
    }
}

