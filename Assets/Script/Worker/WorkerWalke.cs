using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class WorkerWalke : WorkerBehaviour
{
    public float speed = 2f;
    public Vector2 rangeRandomWaypoint;

    public List<Transform> waypoints = new List<Transform>();
    private int index = 0;
    
    protected override void Start()
    {
        base.Start();
        int random = (int)Random.Range(rangeRandomWaypoint.x,rangeRandomWaypoint.y);
        for (int i = 0; i < random; i++)
        {
            waypoints.Add(VivariumManager.instance.RandomWaypoint());
        }
    }

    protected override void Update()
    {
        base.Update();
        Transform target = waypoints[index];

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 2f)
        {
            index++;
            if (index >= waypoints.Count) index = 0;
        }

    }

    private void OnMouseEnter()
    {
        LookEmotion(worker.currentEnergy,worker.energy);
    }

    private void OnMouseExit()
    {
        emotionVisual.gameObject.SetActive(false);
    }

    public void TakeEmployer()
    {
        if(GameManager.instance.gameMode != GameMode.ChoiceWorker) return;
        
        GameManager.instance.ChangePlanning(gameObject, worker.id);
    }
}
