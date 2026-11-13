using System;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool isDraggind = false;
    public Vector2 offset;

    private void Update()
    {
        if (isDraggind )
        { 
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDraggind = true;
    }

    private void OnMouseUp()
    {
        isDraggind = false;
    }
}
