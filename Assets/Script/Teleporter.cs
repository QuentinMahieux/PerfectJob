using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string tagTeleport = "Worker";
    public Transform teleportPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagTeleport))
        {
            other.transform.position = teleportPoint.position;
        }
    }
}