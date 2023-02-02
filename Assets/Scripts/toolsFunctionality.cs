using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolsFunctionality : drag
{

    public override void OnDraggableEntered()
    {
        
    }
    public void OnMouseUp()
    {
        Debug.Log($"{this.name} dropped");
    }



}
