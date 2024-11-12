using UnityEngine;
using System;

public enum EventType
{
    Study,
    Sport,
    Entertainment
}

public enum Place
{
    SnellLibrary,
    CarterField,
    SquashBusters,
    MarinoCenter,
    CurryStudentCenter
}

[CreateAssetMenu(fileName = "New Event", menuName = "Event Data")]

public class EventData : ScriptableObject
{
    public string title;
    public EventType eventType;
    public int Year;
    public int Month;
    public int Day;
    public int Hour;
    public Place place;
    public int numberOfParticipants;
    [TextArea] public string description;
}