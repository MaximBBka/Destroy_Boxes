using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGround = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Robot"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Robot"))
        {
            isGround = false;
        }
    }
}
