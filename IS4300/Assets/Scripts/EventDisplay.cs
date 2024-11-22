using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventDisplay : MonoBehaviour
{
    public EventList eventList; // Assign your EventListSO here
    public GameObject buttonPrefab; // Assign your button prefab
    public Transform buttonParent; // Assign the parent (e.g., Content object in the Scroll View)

    void Start()
    {
        DisplayEvents();
    }

    void DisplayEvents()
    {
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject); // Clear existing buttons if any
        }

        foreach (var eventSO in eventList.eventList)
        {
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            // Assign data to child text objects
            AssignEventDataToUI(button, eventSO);

            button.GetComponentInChildren<TMP_Text>().text = eventSO.title;
            
            // Add Yes button listener to remove the event
            Transform widget = button.transform.Find("Event Widget/CancelConfirmation");
            Button yesButton = widget.Find("Yes").GetComponent<Button>();
            yesButton.onClick.AddListener(() => RemoveEvent(eventSO, button));
        }
    }
    
    
    void AssignEventDataToUI(GameObject button, EventData eventSO)
    {
        // Find the parent object holding all the text components
        Transform widget = button.transform.Find("Event Widget");
        // Assuming TextMeshPro is used for the text components
        TMP_Text titleText = widget.transform.Find("EventTitle").GetComponent<TMP_Text>();
        TMP_Text timeText = widget.transform.Find("EventTime").GetComponent<TMP_Text>();
        TMP_Text placeText = widget.transform.Find("EventPlace").GetComponent<TMP_Text>();
        TMP_Text participantsText = widget.transform.Find("Participants").GetComponent<TMP_Text>();
        TMP_Text typeText = widget.transform.Find("EventType").GetComponent<TMP_Text>();
        TMP_Text descriptionText = widget.transform.Find("EventDescription").GetComponent<TMP_Text>();

        // Assign data with constant text prefixes
        if (titleText != null) titleText.text = "Event Title: " + eventSO.title;
        if (timeText != null) timeText.text = "Event Time: " + eventSO.date;
        if (placeText != null) placeText.text = "Event Place: " + eventSO.place;
        if (participantsText != null) participantsText.text = "Participants: " + eventSO.numberOfParticipants;
        if (typeText != null) typeText.text = "Event Type: " + eventSO.eventType;
        if (descriptionText != null) descriptionText.text = "Description: " + eventSO.description;
    }
    
    void RemoveEvent(EventData eventSO, GameObject button)
    {
        if (eventList == null)
        {
            eventList = ScriptableObject.CreateInstance<EventList>();
            Debug.Log("createList initialized as a new EventList.");
        }
        
        // Remove the event from the list
        if (eventList.eventList.Contains(eventSO))
        {
            eventList.eventList.Remove(eventSO);
            Debug.Log($"Removed event: {eventSO.title}");
        }
        
#if UNITY_EDITOR
        EditorUtility.SetDirty(eventList);
        AssetDatabase.SaveAssets(); 
#endif

        // Destroy the button
        Destroy(button);

        // Optionally, refresh the event list UI
        DisplayEvents();
    }
}
