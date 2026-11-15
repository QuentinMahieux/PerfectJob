using System;
using UnityEngine;

public class Grab : MonoBehaviour
{
    protected bool isDraggind = false;
    public bool returneStart;
    private Vector3 oldPosition;
    public Vector2 offset;

    protected virtual void Update()
    {
        if (isDraggind)
        { 
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    protected virtual void  OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDraggind = true;
        
        oldPosition = transform.position;
    }

    protected virtual void OnMouseUp()
    {
        isDraggind = false;
        if(returneStart) transform.position = oldPosition;
    }
}
