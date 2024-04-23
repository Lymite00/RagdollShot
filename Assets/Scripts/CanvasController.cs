using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Slider timeSlider;
    void Start()
    {
        timeSlider.value = Time.timeScale;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Time.timeScale = timeSlider.value;
    }
}
