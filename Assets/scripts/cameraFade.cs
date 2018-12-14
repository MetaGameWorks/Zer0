using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFade : MonoBehaviour
{
    public Texture2D fadeTexture;   // the texture that will overlay the screen to black it out
    public float fadeSpeed = 0.8f;  // the speed at which the screen will fade in and out

    int drawnDepth = -1000;         // the layer at which the fade texture will redner, this will ensure that it's on top
    float alpha = 1f;               // the opacity oi the fade texture between the numbers 0 and 1
    int fadeDir = -1;               // the direction to fade: in = -1 or out = 1

    private void OnGUI()
    {
        // fade in/ out the alpha value using the direction, a speed an Time.deltaTime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // keeps the value between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);        // set alpha
        GUI.depth = drawnDepth;                                                     // set depth
        GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), fadeTexture); // draws the overlay texture
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;    
        return (fadeSpeed); // return fadespeed to load level at the right time
    }

    // fades in the moment the level was loaded
    private void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }

    private void Update()
    {
        // set fade out after a few seconds
    }
}
