using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CameraPosition : MonoBehaviour
{
    public GUISkin myskin = null;

    //This is the field of view that the Camera has
    float m_FieldOfView;

    void Start()
    {
        //Start the Camera field of view at 60
        m_FieldOfView = 60.0f;
    }

    void Update()
    {
        //Update the camera's field of view to be the variable returning from the Slider
        Camera.main.fieldOfView = m_FieldOfView;
    }

    void OnGUI()
    {
        //Set up the maximum and minimum values the Slider can return (you can change these)
        GUI.skin = myskin;
        float max, min;
        max = 80.0f;
        min = 20.0f;
        //This Slider changes the field of view of the Camera between the minimum and maximum values
        m_FieldOfView = GUI.HorizontalSlider(new Rect(120, 155, 100, 40), m_FieldOfView, min, max);
        GUI.Label(new Rect(45, 150, 100, 40), "Zoom In/Out");

        //Sound
        //m_FieldOfView = GUI.HorizontalSlider(new Rect(120, 255, 100, 40), m_FieldOfView, min, max);
        //GUI.Label(new Rect(45, 250, 100, 40), "Volume");

        GUI.Label(new Rect(45, 250, 100, 40), "Leaderboard");
        GUI.Button(new Rect(120, 250, 100, 40), " Rankings");
    }
}
