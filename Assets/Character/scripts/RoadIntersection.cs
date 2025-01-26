using System;
using Unity.VisualScripting;
using UnityEngine;

public class RoadIntersection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript.RoadIntersection = transform.position;
            playerScript.InTurningZone = true;
            Debug.Log("Player entered Road Intersection");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerScript.InTurningZone = false;
            Debug.Log("Player exited Road Intersection");
        }
    }
}
