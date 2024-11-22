using UnityEngine;
using System;
using TMPro;

public enum EventType
{
    Study,
    Sport,
    Entertainment,
    Unknown
}

public enum Place
{
    SnellLibrary,
    CarterField,
    SquashBusters,
    MarinoCenter,
    CurryStudentCenter,
    RyderHall,
    Unknown
}

public class EventData : MonoBehaviour
{
    [SerializeField] public string title;
    [SerializeField] public EventType eventType;
    //public int Year;
    //public int Month;
    //public int Day;
    //public int Hour;
    [SerializeField] public string date;
    [SerializeField] public Place place;
    [SerializeField] public string numberOfParticipants;
    [SerializeField] [TextArea] public string description;
    
    public override bool Equals(object item)
    {
        if (item == null || !(item is EventData))
        {
            return false;
        }
        
        EventData other = (EventData)item;
        return this.title == other.title;
    }
    
    public static EventType GetEventType(string eventsType)
    {
        if (eventsType == "Study")
        {
            return EventType.Study;
        } 
        else if (eventsType == "Sport")
        {
            return EventType.Sport;
        }
        else if (eventsType == "Entertainment")
        {
            return EventType.Entertainment;
        }
        else
        {
            return EventType.Unknown;
        }
    }

    public static Place GetPlace(string places)
    {
        if (places == "Snell Library")
        {
            return Place.SnellLibrary;
        } 
        else if (places == "Ryder")
        {
            return Place.RyderHall;
        }
        else if (places == "Carters Field")
        {
            return Place.CarterField;
        }
        else
        {
            return Place.Unknown;
        }
    }
}