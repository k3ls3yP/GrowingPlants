using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterFill : MonoBehaviour
{
    public Slider slider;
    public float totalWater = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }
    private void Update()
    {
        DecreaseWater(.2f * Time.deltaTime);
    }
    public void AddWater(float water)
    {
        slider.value+=water;
        totalWater += water;
    }

    public void SetMaxWater(int water)
    {
        slider.maxValue = water;
    }
    public void DecreaseWater(float water)
    {
        if (slider.value > 0)
        {
            slider.value -= water;
        }

    }
    public float GetTotalWater()
    {
        return totalWater;
    }
}
