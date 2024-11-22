using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EventList : MonoBehaviour
{
    public List<EventData> allEvent = new List<EventData>();
    public List<EventData> myCreatedEvents = new List<EventData>();
    public List<EventData> myJoinedEvents = new List<EventData>();
    public List<EventData> searchedEvents = new List<EventData>();
    
    public void AddEvent(EventData thisEvent, List<EventData> eventList)
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

    public void RemoveEvent(EventData thisEvent, List<EventData> eventList)
    {
        if (eventList.Contains(thisEvent))
        {
            eventList.Remove(thisEvent);
        }
    }

    public List<EventData> searchEvents(string searchString, List<EventData> eventList)
    {
        List<EventData> searchEventList = new List<EventData>();
        DateTime searchDate;

        // Check if the search string is a valid date
        bool isDateSearch = DateTime.TryParse(searchString, out searchDate);

        foreach (EventData thisEvent in eventList)
        {
            DateTime eventDate;

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
