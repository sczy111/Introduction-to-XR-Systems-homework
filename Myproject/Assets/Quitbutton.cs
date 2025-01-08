using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitbutton : MonoBehaviour
{
    public void QuitApplication()
    {
#if UNITY_EDITOR
        // Stop play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application in a build
        Application.Quit();
#endif
    }
}
