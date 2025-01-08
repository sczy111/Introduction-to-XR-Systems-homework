using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionButton : MonoBehaviour
{
    public Transform roomPosition; 
    public Transform externalViewPoint;
    void Start()
    {
        if (roomPosition == null || externalViewPoint == null)
        {
            Debug.LogError("Positions are not assigned in the Inspector!");
            return;
        }

        
        transform.position = roomPosition.position;
        transform.rotation = roomPosition.rotation;
    }

    public void GoToRoom()
    {
        
        transform.position = roomPosition.position;
        transform.rotation = roomPosition.rotation;
        Debug.Log("Moved to Room");
    }

    public void GoToExternalView()
    {
        
        transform.position = externalViewPoint.position;
        transform.rotation = externalViewPoint.rotation;
        Debug.Log("Moved to External View");
    }
}
