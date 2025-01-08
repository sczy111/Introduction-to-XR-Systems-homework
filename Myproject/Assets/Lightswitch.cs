using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
public class LightSwitch : MonoBehaviour
{
    public Light roomlight; 
    public Color[] colors = new Color[] {
        Color.white, 
        Color.red,   
        Color.blue,  
        Color.green  
    }; 
    private int currentColorIndex = 0; 

    public InputActionReference gripPressAction; 

    void Start()
    {
        if (roomlight == null)
        {
            Debug.LogError("roomlight is not assigned in the Inspector!");
            return;
        }

        if (colors.Length == 0)
        {
            Debug.LogError("No colors assigned to the colors array!");
            return;
        }

        
        roomlight.color = colors[currentColorIndex];

        
        if (gripPressAction != null)
        {
            gripPressAction.action.Enable();
            gripPressAction.action.performed += OnGripPressed;
        }
    }

    private void OnGripPressed(InputAction.CallbackContext context)
    {
        ToggleLightColor();
    }

    public void ToggleLightColor()
    {
        if (roomlight != null && colors.Length > 0)
        {
            
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            roomlight.color = colors[currentColorIndex];
        }
    }

    private void OnDestroy()
    {
        if (gripPressAction != null)
        {
            gripPressAction.action.performed -= OnGripPressed;
        }
    }
}


