using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    public Vector3 originalPosition;
    public bool putBack;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public bool IsDragging()
    {
        return DragDropManager.Instance.currentDraggedItem == this;
    }

    public virtual void OnDropThis(drop droppedOn)
    {
        
    }
    public bool GetPutBack()
    {
        return putBack;
    }
}
