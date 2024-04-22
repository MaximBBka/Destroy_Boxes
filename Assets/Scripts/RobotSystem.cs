
using UnityEngine;


public class RobotSystem : MonoBehaviour
{
    [SerializeField] private Animator jump;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float heightJump;

    [SerializeField] private GroundSensor groundSensor;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && groundSensor.isGround)
        {
            //jump.SetTrigger("isAir");
            rb.AddForce(new Vector3(0, heightJump, 0));
        }
    }

}
