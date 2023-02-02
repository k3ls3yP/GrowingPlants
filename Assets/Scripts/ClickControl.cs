using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    public static string nameOfObj;


    private void OnMouseDown()
    {
        Debug.Log($"clicked on {this.name}");

    }
}
