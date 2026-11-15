using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxUnique : MonoBehaviour
{
    [HideInInspector] public string id;
    

    public WorkerBehaviour workerVisual;
    
    public GameObject parentSlot;
    private List<SlotActivity> slots = new List<SlotActivity>();
    
    private Worker currentWorker;
    private bool isWork;
    private int index;

    private void Start()
    {
        id = Guid.NewGuid().ToString();
        
        slots.Clear();
        foreach (SlotActivity slot in parentSlot.GetComponentsInChildren<SlotActivity>())
        {
            slots.Add(slot);
        }
        
        slots[0].taskView.SetActive(true);
        workerVisual.gameObject.SetActive(false);
    }
    
    public void StartJob(string workerID)
    {
        isWork = true;
        workerVisual.gameObject.SetActive(true);

        currentWorker = GameManager.instance.FindWorker(workerID);
        
        workerVisual.Instantiate(currentWorker);
    }

    public void EndJob()
    {
        if(!isWork) return;
        
        isWork = false;
        workerVisual.gameObject.SetActive(false);
        
        GameManager.instance.pullVivarium.Add(currentWorker.id);
        currentWorker = null;
    }
    
    public void ChangeTask()
    {
        if(!isWork) return;
        
        slots[index].taskView.SetActive(false);
        index++;
        if (index >= slots.Count)
            index = 0;
        
        slots[index].taskView.SetActive(true);
    }

    public void AddWorker()
    {
        if(isWork) return;
        GameManager.instance.ChangeKeepVivarium(id);
    }
}
