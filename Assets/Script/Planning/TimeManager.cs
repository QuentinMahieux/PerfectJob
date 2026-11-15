using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public GameObject boxParent;
    public List<BoxUnique> boxs;
    public float secondInterval = 2f;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        boxs.Clear();
        foreach (BoxUnique box in boxParent.GetComponentsInChildren<BoxUnique>())
        {
            boxs.Add(box);
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondInterval);
            foreach (BoxUnique box in boxs)
            {
                box.ChangeTask();
            }
        }
    }
}
