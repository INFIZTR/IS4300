using System;
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

    public List<EventData> searchEvents(string searchString)
    {
        List<EventData> searchEventList = new List<EventData>();
        DateTime searchDate;

        // Check if the search string is a valid date
        bool isDateSearch = DateTime.TryParse(searchString, out searchDate);

        foreach (EventData thisEvent in eventList)
        {
            DateTime eventDate;

            // Check event type, title, place, or date
            string a = thisEvent.title.ToLower();
            string c = thisEvent.place.ToString().ToLower() + "\u200B";
            string b = searchString.ToLower();
            if (thisEvent.eventType.ToString().ToLower() + "\u200B"== searchString.ToLower() ||  
                thisEvent.title.ToLower()== searchString.ToLower() ||
                thisEvent.place.ToString().ToLower()+ "\u200B"== searchString.ToLower() ||
                (isDateSearch &&
                 DateTime.TryParse(thisEvent.date, out eventDate) &&
                 eventDate.Date == searchDate.Date))
            {
                searchEventList.Add(thisEvent);
            }
        }

        return searchEventList;
    }
}
