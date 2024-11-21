using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event List", menuName = "Event List")]
public class EventList : ScriptableObject
{
    public List<EventData> eventList = new List<EventData>();
    
    public void AddEvent(EventData thisEvent)
    {
        if (thisEvent.title == null)
        {
            return;
        }
       else if (!eventList.Contains(thisEvent))
        {
            eventList.Add(thisEvent);
        }
        else
        {
            Debug.Log("Event already exists.");
        }
    }

    public void RemoveEvent(EventData thisEvent)
    {
        if (eventList.Contains(thisEvent))
        {
            eventList.Remove(thisEvent);
        }
    }
}
