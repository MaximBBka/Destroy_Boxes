using UnityEditor;
using UnityEngine;

public class RobotSystem : MonoBehaviour
{
    [SerializeField] private Explorer explorer;
    [SerializeField] public Animator animatorRobot;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float heightJump;
    [SerializeField] private GroundSensor groundSensor;
    [SerializeField] private GameObject WindowMobile;
    private float speedAnimation;
    private void Update()
    {
        ChekMobileVersion();
        if (!explorer.isMobile)
        {
            Move();
            RotationPlayer();
            JumpPlayer();
        }
    }
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

        animatorRobot.SetFloat("Speed", Mathf.Abs(horizontal * moveSpeed));
    }
    public void RotationPlayer()
    {
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
    public void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundSensor.isGround)
        {
            animatorRobot.SetTrigger("isAir");
            rb.AddForce(new Vector3(0, heightJump, 0));
        }
    }
    public void ChekMobileVersion()
    {
        WindowMobile.gameObject.SetActive(explorer.isMobile);
    }
    public void MoveLeftMobile(float time)
    {
        rb.velocity = new Vector2(-time * moveSpeed, rb.velocity.y);
        transform.localRotation = Quaternion.Euler(0, 50f, 0);
        speedAnimation += Time.deltaTime;
        animatorRobot.SetFloat("Speed", time);
    }
    public void MoveRightMobile(float time)
    {
        rb.velocity = new Vector2(time * moveSpeed, rb.velocity.y);
        transform.localRotation = Quaternion.Euler(0, -50f, 0);
        animatorRobot.SetFloat("Speed", time);
    }
    public void JumpMobile()
    {
        if (groundSensor.isGround)
        {
            animatorRobot.SetTrigger("isAir");
            rb.AddForce(new Vector3(0, heightJump, 0));
        }
    }
    public void Movement(Vector2 directon, float time)
    {
        if (directon == Vector2.left)
        {
            MoveLeftMobile(time);
        }
        if (directon == Vector2.right)
        {
            MoveRightMobile(time);
        }
    }
}
