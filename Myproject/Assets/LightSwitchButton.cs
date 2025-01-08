using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchButton : MonoBehaviour
{
    public Light roomlight;
    public Color[] colors = new Color[] {
        Color.white,
        Color.red,
        Color.blue,
        Color.green
    };
    private int currentColorIndex = 0;

    void start()
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
    }

    public void TogglelightColor()
    {
        if (roomlight != null && colors.Length > 0)
        {
            
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            roomlight.color = colors[currentColorIndex];
        }
    }
}

