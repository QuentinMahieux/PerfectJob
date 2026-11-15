using System;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    
    public Texture2D defaultCursor;
    public Texture2D selectCursor;
    public Texture2D goWorkCursor;
    public Texture2D zoomCursor;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetMode(CursorType cursorMode)
    {
        switch (cursorMode)
        {
            case CursorType.Default:
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Select:
                Cursor.SetCursor(selectCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.GoWork:
                Cursor.SetCursor(goWorkCursor, Vector2.zero, CursorMode.Auto);
                break;
            case CursorType.Zoom:
                Cursor.SetCursor(zoomCursor, Vector2.zero, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
    
}

public enum CursorType
{
    Default,
    Select,
    GoWork,
    Zoom
}