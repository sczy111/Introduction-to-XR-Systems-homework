using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class LightSwitchShared : MonoBehaviour
{
    public Light roomLight; 
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
        
        if (roomLight == null)
        {
            Debug.LogError("roomLight is not assigned in the Inspector!");
            return;
        }

        if (colors.Length == 0)
        {
            Debug.LogError("No colors assigned to the colors array!");
            return;
        }

        
        roomLight.color = colors[currentColorIndex];

        
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

    
    public void ToggleLightColorFromButton()
    {
        ToggleLightColor(); 
    }

    
    private void ToggleLightColor()
    {
        if (roomLight != null && colors.Length > 0)
        {
            
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            roomLight.color = colors[currentColorIndex];
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
