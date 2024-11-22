using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchController : MonoBehaviour
{
    public EventList allEvent;
    
    public EventList searchedEvent;
    
    public TMP_Text searchText;

    public void Search()
    {
        List<EventData> list = allEvent.searchEvents(searchText.text);
        foreach (EventData eventData in list)
        {
            searchedEvent.AddEvent(eventData);
        }
    }
}
