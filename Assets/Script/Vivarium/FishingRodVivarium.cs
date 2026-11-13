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
        newWorker = Instantiate(prefabWorker, hook.position, hook.rotation);
        newWorker.Instantiate(GameManager.instance.TakeCurrentWorker());
    }

    void Update()
    {
        if (!isDropped)
        {
            Vector3 velocity = Vector3.down.normalized * speed;
        
            rb.linearVelocity = velocity;
            newWorker.transform.position = hook.position;
        }
        else
        {
            Vector3 velocity = Vector3.down.normalized * speed;
        
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
