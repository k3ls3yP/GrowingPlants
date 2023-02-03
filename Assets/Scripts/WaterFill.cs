using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterFill : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetWater(int water)
    {
        slider.value = water;
    }

    public void SetMaxWater(int water)
    {
        slider.maxValue = water;
    }
}
