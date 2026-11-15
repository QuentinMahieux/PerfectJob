using System.Collections.Generic;
using UnityEngine;

public class SlotGestionnaire : MonoBehaviour
{
    [Header("Slot")]
    public GameObject slotParent;
    public List<SlotActivity> currentSlots;
    void Start()
    {
        foreach (SlotActivity slot in slotParent.GetComponentsInChildren<SlotActivity>())
        {
            currentSlots.Add(slot);
        }
    }

    void AddWorker(Worker worker)
    {
        
    }

    void RemoveWorker()
    {
        
    }
}
