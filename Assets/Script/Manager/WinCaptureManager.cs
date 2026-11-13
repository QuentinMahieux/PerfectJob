using UnityEngine;

public class WinCaptureManager : MonoBehaviour
{
    public WorkerBehaviour worker;
    void OnEnable()
    {
        worker.Instantiate(GameManager.instance.TakeCurrentWorker());
    }

    void Update()
    {
        
    }
}
