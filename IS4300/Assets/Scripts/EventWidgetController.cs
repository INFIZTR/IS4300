using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWidgetController : MonoBehaviour
{
    // Reference to the event widget prefab
    public GameObject eventWidgetPrefab;
    

    // Method to instantiate the event widget prefab
    public void InstantiateEventWidget(Transform transform)
    {
        if (eventWidgetPrefab != null)
        {
            // Instantiate the prefab at the specified parent position (optional)
            GameObject newWidget = Instantiate(eventWidgetPrefab, transform);
            
            // Optionally set the position and rotation if not using parentTransform
            newWidget.transform.position = new Vector3(0, 0, 0); // Set to desired position
            newWidget.transform.rotation = Quaternion.identity;
        }
        else
        {
            Debug.LogWarning("Event widget prefab is not assigned!");
        }
    }
}