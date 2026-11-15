using UnityEngine;
using UnityEngine.EventSystems;

public class CursorZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CursorType cursorType;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        CursorManager.instance.SetMode(cursorType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.instance.SetMode(CursorType.Default);
    }
}
