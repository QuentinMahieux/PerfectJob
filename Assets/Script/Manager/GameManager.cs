using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Worker currentWorker;
    
    public GameMode gameMode;

    [Header("Last Slot Workers")] 
    public string slotID;
    
    [Header("Data")]
    public List<Worker> workers;
    public List<string> pullVivarium = new List<string>();

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ChargePlanning();
    }

    //Lorsqu'un employé doit être capturer
    public void ChargeFishing()
    {
        EnableScene("Fishing");
        gameMode = GameMode.Default;
    }
    
    //Lorsqu'un employé est caputré
    public void ChargeWinCaptureWorker(Worker worker, bool isFinish = false)
    {
        currentWorker = worker;
        EnableScene("CaptureWorker");
    }

    public void ChargeVivarium()
    {
        EnableScene("Vivarium");
        gameMode = GameMode.Default;
    }

    public void ChangeNewVivarium()
    {
        gameMode = GameMode.NewVivarium;
        EnableScene("Vivarium");
    }

    public void ChangeKeepVivarium(string newslotID)
    {
        slotID = newslotID;
        
        gameMode = GameMode.ChoiceWorker;
        EnableScene("Vivarium");
        CursorManager.instance.SetMode(CursorType.GoWork);

    }

    public void ChangePlanning(GameObject destoyable, string workerID)
    {
        gameMode = GameMode.Default;
        EnableScene("Planning");

        foreach (BoxUnique box in TimeManager.instance.boxs)
        {
            if (box.id == slotID)
            {
                box.StartJob(workerID);
                break;
            }
        }
        
        Destroy(destoyable);
    }
    
    public void ChargePlanning()
    {
        EnableScene("Planning");
        gameMode = GameMode.Default;
    }
    
    public Worker TakeCurrentWorker()
    {
        return currentWorker;
    }

    void EnableScene(string exception)
    {
        CursorManager.instance.SetMode(CursorType.Default);
        
        foreach (Transform scene in transform)
        {
            if (scene.gameObject.name == exception)
            {
                scene.gameObject.SetActive(true);
            }
            else scene.gameObject.SetActive(false);
        }
    }
    
    public Worker FindWorker(string id)
    {
        foreach (Worker worker in workers)
        {
            if (worker.id == id) return worker;
        }
        return null;
    }
}

public enum GameMode
{
    Default,
    ChoiceWorker,
    NewVivarium
}