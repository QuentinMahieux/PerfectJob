using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ActivityGenerator : MonoBehaviour
{
    public ActivityElement activityPrefab;
    public Transform spawnPoint;
    public float scaleEnterActivity;
    private int index = 0;
    
    public List<ActivityData> Defaultactivities = new List<ActivityData>();
    private List<ActivityDataInstance> DefaultactivitieInstances = new List<ActivityDataInstance>();


    public void Start()
    {
        foreach (ActivityData activity in Defaultactivities)
        {
            DefaultactivitieInstances.Add(activity.Instance());
        }
        SpawnElement(DefaultactivitieInstances);
    }

    void SpawnElement(List<ActivityDataInstance> activities)
    {
        foreach (ActivityDataInstance activity in activities)
        {
            Vector3 position = new Vector3(spawnPoint.localPosition.x, spawnPoint.localPosition.y + (scaleEnterActivity * index), spawnPoint.localPosition.z);
            
            ActivityElement newElement = Instantiate(activityPrefab,  position, spawnPoint.rotation, transform);
            newElement.Instanciate(activity);

            index++;
        }
    }
}
