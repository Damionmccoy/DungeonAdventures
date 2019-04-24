using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQGEventSystem
{
    public class EventSystemManager : MonoBehaviour
    {

        #region Instance Var
        private static EventSystemManager instance;
        public static EventSystemManager Instance //creates an instance of this class;
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<EventSystemManager>();
                }
                return instance;
            }
        }
        #endregion

        public delegate void EventListener(EventInfo eventInfo);
        Dictionary<System.Type, List<EventListener>> eventListeners;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }


        //Some magick yet to understand
        public  void RegisterListener<T>(System.Action<T> listener) where T : EventInfo
        {
            System.Type eventType = typeof(T);

            if (eventListeners == null)
            {
                eventListeners = new Dictionary<System.Type, List<EventListener>>();
            }

            if(eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null)
            {
                eventListeners[eventType] = new List<EventListener>();
            }


            EventListener wrapper = (eventInfo) => { listener((T)eventInfo); };
            
            eventListeners[eventType].Add(wrapper);
        }
        


        public void UnregisterListener<T>(System.Action<T> listener) where T : EventInfo
        {
            System.Type eventType = typeof(T);

            //Wrap a type conversion around the event listener.
            EventListener wrapper = (eventInfo) => { listener((T)eventInfo); };

            if (eventListeners == null)
            {
                //there is nothing to unregister  from
                return;
            }

            if (eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null)
            {
                //this event isn't registered so no need to unregister it
                return;
            }

            if (eventListeners[eventType].Contains(wrapper))
            {
                eventListeners[eventType].Remove(wrapper);
            }
            

        }

        /// <summary>
        /// Fires the callback so that anyone listening will get it.
        /// </summary>
        /// <param name="eventType"> This is the EVENT_TYPE we are calling</param>
        /// <param name="infoClass">This is the info class that your sending to anyone listening</param>
        public void FireEvent(EventInfo infoClass)
        {
            System.Type trueEventInfoClass = infoClass.GetType();

            if(eventListeners == null || eventListeners[trueEventInfoClass] == null)
            {
                //if no one is listening then we are done.
                return;
            }

            foreach(EventListener e in eventListeners[trueEventInfoClass])
            {
                e(infoClass);
            }
        }
    }

    /// <summary>
    /// THis  is  the  base class for info  sent via the event system manager. Any class that needs to have its own event info
    /// class with  unique info needs to inharet from this class; This needs to be a base class because we want a generic way to send
    /// an info class to the listener.
    /// </summary>
    public abstract class EventInfo 
    {
        /// <summary>
        /// This is some discription  of the event for debuging purposes.
        /// </summary>
        public string EventDescription;
    }

    public class DoorMessage: EventInfo
    {
        public string DoorEntranceName;
        public string DoorExitName;
        public bool Unlock;
    }

    public class DebugEventInfo: EventInfo
    {
        /// <summary>
        /// This is an int  between 0-5 were 0 is not important and 5 is super important;
        /// </summary>
        public int DebugLevel;
    }

    /// <summary>
    /// This is an info class used to send death event info to whomever wants it.
    /// </summary>
    public  class UnitDeathEventInfo : EventInfo
    {
        /// <summary>
        /// This is the game object that is calling the death event.
        /// </summary>
        public GameObject UnitDead { get; set; }

        /// <summary>
        /// This is a coroutine to fire off if needed;
        /// </summary>
        public string NamedCoroutine { get; set; }
    }

    /// <summary>
    /// This is an info class that tells anyone listening who was damaged how much damage needs to be applyed and 
    /// what caused the damage;
    /// </summary>
    public class UnitDamageEventInfo : EventInfo
    {
        /// <summary>
        /// This is the name of the game object hit
        /// </summary>
        public string UnitName;

        /// <summary>
        /// The Amount of damage that is taken.
        /// </summary>
        public int DamageAmount;

        /// <summary>
        /// The name of the object doing damage
        /// </summary>
        public string DamagerName;
        
        
    }
}

