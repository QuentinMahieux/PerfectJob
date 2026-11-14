using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Worker currentWorker;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ChargeFishing();
    }

    //Lorsqu'un employé doit être capturer
    public void ChargeFishing()
    {
        EnableScene("Fishing");
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
    }
    
    public void ChargePlanning()
    {
        EnableScene("Planning");
    }
    
    public Worker TakeCurrentWorker()
    {
        return currentWorker;
    }

    void EnableScene(string exception)
    {
        foreach (Transform scene in transform)
        {
            if (scene.gameObject.name == exception)
            {
                scene.gameObject.SetActive(true);
            }
            else scene.gameObject.SetActive(false);
        }
    }
}
