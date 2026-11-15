using System;
using UnityEngine;

public class FishingRodVivarium : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    private bool isDropped = false;
    private Vector3 defaultPosition;

    public Transform hook;
    public WorkerBehaviour prefabWorker;
    private WorkerBehaviour newWorker;
    
    void Awake()
    {
        defaultPosition = transform.position;
    }

    private void OnEnable()
    {
        transform.position = defaultPosition;
        
        if(GameManager.instance.gameMode == GameMode.NewVivarium)
        {
            isDropped = false;
            newWorker = Instantiate(prefabWorker, hook.position, hook.rotation, transform.parent);
            
            newWorker.Instantiate(GameManager.instance.TakeCurrentWorker());
        }

        if(GameManager.instance.pullVivarium == null) return;
        foreach (string worker in GameManager.instance.pullVivarium)
        {
            newWorker = Instantiate(prefabWorker, hook.position, hook.rotation, transform.parent);
            newWorker.Instantiate(GameManager.instance.FindWorker(worker));
            
            GameManager.instance.pullVivarium.Remove(worker);
        }
    }

    void Update()
    {
        if(GameManager.instance.gameMode != GameMode.NewVivarium) return;
        
        if (!isDropped)
        {
            Vector3 velocity = Vector3.down.normalized * speed;
        
            rb.linearVelocity = velocity;
            newWorker.transform.position = hook.position;
        }
        else
        {
            Vector3 velocity = Vector3.up.normalized * speed;
        
            rb.linearVelocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            isDropped = true;
        }
    }
}
