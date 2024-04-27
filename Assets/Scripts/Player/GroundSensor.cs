using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGround = false;
    private RobotSystem system;
    private void Start()
    {
        system = transform.parent.GetComponent<RobotSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Robot") && !other.CompareTag("Delete"))
        {
            isGround = true;
            system.ResetJumps();
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
