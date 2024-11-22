using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class CreateEventController : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text eventTypeText;
    public TMP_Text placeText;
    public TMP_Text numberOfParticipantsText;
    public TMP_Text dateText;
    public TMP_Text descriptionText;
    
    public EventList eventList;
    public EventList createList;
    
    public void CreateEvent()
    {
        if (createList == null)
        {
            createList = ScriptableObject.CreateInstance<EventList>();
            Debug.Log("createList initialized as a new EventList.");
        }
        
        EventData eventData = new EventData();
        eventData.title = titleText.text;
        if (EventData.GetEventType(eventTypeText.text) != EventType.Unknown)
        {
            eventData.eventType = EventData.GetEventType(eventTypeText.text);
        }
        
        if (EventData.GetPlace(placeText.text) != Place.Unknown)
        {
            eventData.place = EventData.GetPlace(placeText.text);
        }
        
        eventData.numberOfParticipants = numberOfParticipantsText.text;
        eventData.description = descriptionText.text;
        eventData.date = dateText.text;
        
        eventList.AddEvent(eventData);
        createList.AddEvent(eventData);
        
#if UNITY_EDITOR
        EditorUtility.SetDirty(eventList);
        EditorUtility.SetDirty(createList);
        AssetDatabase.SaveAssets(); 
#endif
    }
}
