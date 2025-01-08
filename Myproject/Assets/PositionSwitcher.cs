using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
public class PositionSwitcher : MonoBehaviour
{
    public Transform roomPosition; 
    public Transform externalViewPoint; 
    public InputActionReference xButtonAction; 

    private bool isExternalView = false; 
    void Start()
    {
        if (roomPosition == null || externalViewPoint == null)
        {
            Debug.LogError("Positions are not assigned in the Inspector!");
            return;
        }

        
        transform.position = roomPosition.position;
        transform.rotation = roomPosition.rotation;

        
        if (xButtonAction != null)
        {
            xButtonAction.action.Enable();
            xButtonAction.action.performed += OnXButtonPressed;
        }
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        SwitchPosition();
    }

    private void SwitchPosition()
    {
       
        if (isExternalView)
        {
            
            transform.position = roomPosition.position;
            transform.rotation = roomPosition.rotation;
        }
        else
        {
            
            transform.position = externalViewPoint.position;
            transform.rotation = externalViewPoint.rotation;
        }

        
        isExternalView = !isExternalView;
    }

    private void OnDestroy()
    {
        if (xButtonAction != null)
        {
            xButtonAction.action.performed -= OnXButtonPressed;
        }
    }
}






