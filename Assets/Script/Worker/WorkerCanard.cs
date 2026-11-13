using System;
using UnityEngine;

public class WorkerCanard : WorkerBehaviour
{
    [Header("Canard")] 
    public float speed;

    private bool isGrab = false;
    private Transform hook;

    private void Update()
    {
        if (isGrab)
        {
            transform.position = hook.position;
        }
        else
        {
            Vector3 velocity = Vector3.right.normalized * speed;
            velocity.y = rb.linearVelocity.y;
            rb.linearVelocity = velocity;
        }
    }

    public void Stop(float newSpeed, Transform newHook)
    {
        speed = newSpeed;
        hook = newHook;
        rb.linearVelocity = Vector3.zero;
        rb.gravityScale = 0;
        isGrab = true;
    }
}
