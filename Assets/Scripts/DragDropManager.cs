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
            if (raycastHits.Length > 0)
            {
                RaycastHit frontRaycast = raycastHits[0];
                foreach (RaycastHit hit in raycastHits)
                {
                    if (hit.transform.GetComponent<drag>() != null)
                    {
                        SpriteRenderer checkedHit = hit.transform.GetComponent<SpriteRenderer>();
                        if (checkedHit.sortingOrder > frontRaycast.transform.GetComponent<SpriteRenderer>().sortingOrder)
                        {
                            frontRaycast = hit;
                        }
                    }
                }
                if (frontRaycast.transform.GetComponent<drag>() != null)
                {
                    currentDraggedItem = frontRaycast.transform.GetComponent<drag>();
                    currentDraggedItem.originalPosition = frontRaycast.transform.position;
                    //mouse position only
                    offset = currentDraggedItem.originalPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    dropSuccessful = false;
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
                //print(raycastHits.Length);
                //order raycast 
                if (raycastHits.Length > 0)
                {
                    RaycastHit frontRaycast = new RaycastHit();
                    foreach (RaycastHit hit in raycastHits)
                    {
                        //Has drop and not itself
                        if (hit.transform.GetComponent<drop>() != null && currentDraggedItem.transform !=hit.transform)
                        {
                            SpriteRenderer checkedHit = hit.transform.GetComponent<SpriteRenderer>();
                            //what's on top
                            if (frontRaycast.transform == null)
                            {
                                frontRaycast = hit;
                            }
                            else if (checkedHit.sortingOrder >= frontRaycast.transform.GetComponent<SpriteRenderer>().sortingOrder)
                            {
                                frontRaycast = hit;
                                
                            }
                        }
                        
                    }

                    if (currentDraggedItem.transform != frontRaycast.transform && frontRaycast.transform != null)
                    {
                        //using the front hit
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                        currentDraggedItem.transform.position = newPosition;
                        currentDraggedItem.OnDropThis(frontRaycast.transform.GetComponent<drop>());
                        if (!currentDraggedItem.GetPutBack())
                        {
                            dropSuccessful = false;
                        }
                        else
                        {
                            dropSuccessful = true;
                            currentDraggedItem = null;
                        }
                        
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

}
