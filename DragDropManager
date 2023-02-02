using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    public static DragDropManager Instance { get; private set; }
    //[SerializeField] 
    public drag currentDraggedItem;

    public Vector3 offset;
    public bool dropSuccessful;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (currentDraggedItem != null)
        {
            currentDraggedItem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray worldDirection = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            //Vector3 worldOrigin = Camera.main.ViewportToWorldPoint(e.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(worldDirection);
            foreach (RaycastHit hit in raycastHits)
            {
                if (hit.transform.GetComponent<drag>() != null)
                {
                    currentDraggedItem = hit.transform.GetComponent<drag>();
                    currentDraggedItem.originalPosition = hit.transform.position;
                    //mouse position only
                    offset = currentDraggedItem.originalPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    dropSuccessful = false;
                    break;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (currentDraggedItem != null)
            {
                Ray worldDirection = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
                //Vector3 worldOrigin = Camera.main.ViewportToWorldPoint(e.mousePosition);
                RaycastHit[] raycastHits = Physics.RaycastAll(worldDirection);               
                foreach (RaycastHit hit in raycastHits)
                {                   
                    if (hit.transform.GetComponent<drop>() != null)
                    {
                        
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                        //= hit.transform.GetComponent<drop>().transform.position;
                        currentDraggedItem.transform.position = newPosition;
                        currentDraggedItem = null;
                        dropSuccessful = true;
                        break;
                    }
                }
                if (!dropSuccessful)
                {
                    currentDraggedItem.transform.position = currentDraggedItem.originalPosition;
                    currentDraggedItem = null;

                }
            }
        }
    }

    public void WhereDropped()
    {

    }
}
