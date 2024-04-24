using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    //[SerializeField] private RobotSystem robotSystem;
    [SerializeField] private BoxStatus boxStatus;
    [SerializeField] private Rigidbody rb;
    private float speed;

    private void Update()
    {
        speed = rb.velocity.magnitude;
        //robotSystem.animatorRobot.SetBool("isPushing", false);
        if (boxStatus == BoxStatus.Tuch)
        {
            OnTuch();
        }else if (boxStatus == BoxStatus.Free) // Не удаляется коробка в статусе None
        {
            FreeBox();
            LoseGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Robot"))
        {
            boxStatus = BoxStatus.Tuch;
            //robotSystem.animatorRobot.SetBool("isPushing", true);
            
        }  
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Robot"))
        {
            boxStatus = BoxStatus.Free;
        }
    }
    private void OnTuch()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
    private void FreeBox()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, -0.5f);
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
    private void LoseGame()
    {
        if (transform.position.y >= 6.4 && speed <= 0)
        {
            MainUI.Instance.ShowPanelLose();
        }
    }
}
public enum BoxStatus
{
    None,
    Tuch,
    Free,
}