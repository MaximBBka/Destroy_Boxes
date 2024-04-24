using UnityEngine;

public class RobotSystem : MonoBehaviour
{
    [SerializeField] public Animator animatorRobot;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float heightJump;

    [SerializeField] private GroundSensor groundSensor;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

        animatorRobot.SetFloat("Speed", Mathf.Abs(horizontal * moveSpeed));


        if (Input.GetKeyDown(KeyCode.Space) && groundSensor.isGround)
        {
            animatorRobot.SetTrigger("isAir");
            rb.AddForce(new Vector3(0, heightJump, 0));
            
        }
        if (!groundSensor.isGround)
        {
            animatorRobot.SetFloat("Speed", 0f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 50f, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(0, -50, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, -50f, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(0, 50f, 0);
        }
    }

}
