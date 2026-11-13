using System;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool isDraggind = false;
    public bool returneStart;
    private Vector3 oldPosition;
    public Vector2 offset;

    private void Update()
    {
        if (isDraggind)
        { 
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDraggind = true;
        oldPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDraggind = false;
        transform.position = oldPosition;
    }
}
