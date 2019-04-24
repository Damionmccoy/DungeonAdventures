using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQGEventSystem
{ 
    public class DeathListener : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventSystemManager.Instance.RegisterListener<UnitDeathEventInfo> (OnUnitDied);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnUnitDied(EventInfo eventInfo)
        {

            // Change this eventinfo  into what we need?
            UnitDeathEventInfo unitDeathInfo = (UnitDeathEventInfo)eventInfo;

            Debug.Log("Alerted about Unit death: " + unitDeathInfo.UnitDead.name);
        }
    }
}
