﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFade : MonoBehaviour
{
    public Texture2D fadeTexture;
    public float fadeSpeed = 0.8f;

    int drawnDepth = -1000;
    float alpha = 1f;
    int fadeDir = -1;

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawnDepth;
        GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
}