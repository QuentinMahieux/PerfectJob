using System;
using System.Collections;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public bool isFishing = false;
    public bool isFire;
    public float speed;
    public Rigidbody2D rb;
    public Transform hook;

    private Vector3 defaultPositon;

    private Worker workerClass;

    void Awake()
    {
        defaultPositon = transform.position;
    }

    private void OnEnable()
    {
        workerClass = null;
        transform.position = defaultPositon;
        
        rb.linearVelocity =  Vector3.zero;
        
        isFishing = false;
        isFire = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFire = true;
        }
        
        if(isFire) Fire();
        if (isFishing) Fishing();
    }

    void Fire()
    {
        Vector3 velocity = Vector3.down.normalized * speed;
        
        rb.linearVelocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var worker = other.gameObject.GetComponent<WorkerCanard>();
        
        if (worker != null && workerClass == null)
        {
            isFire = false;
            isFishing = true;
            
            worker.transform.parent = this.transform;
            worker.Stop(speed, hook);

            workerClass = worker.worker;

            StartCoroutine(TimeEnd(workerClass, worker.gameObject));
        }
    }

    void Fishing()
    {
        Vector3 velocity = Vector3.up.normalized * speed;
        
        rb.linearVelocity = velocity;
    }

    IEnumerator TimeEnd(Worker worker, GameObject workerObject)
    {
        yield return new WaitForSeconds(3);
        Destroy(workerObject);
        GameManager.instance.ChargeWinCaptureWorker(worker);
    }
}