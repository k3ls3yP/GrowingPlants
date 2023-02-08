using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public bool dropOriginalSpotOnly;
    public Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }
    public virtual void onDrop()
    {
        

    }


}
