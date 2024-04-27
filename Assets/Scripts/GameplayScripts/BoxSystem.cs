using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSystem : MonoBehaviour
{
    [SerializeField] BoxCollider boxColider;
    public BoxColor boxColor;
    private float speed = 0f;
    private float raycastDistance = 1f;
    private bool isMoving = false;

    private void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        if (speed > 0.1f && !isMoving)
        {
            isMoving = true;
        }
        else if (speed <= 0.1f && isMoving)
        {
            isMoving = false;
            CheckCollision();
        }
    }

    private void CheckCollision()
    {
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };

        foreach (Vector3 direction in directions)
        {
            RaycastHit hit;

            // Пускаем луч в текущем направлении
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
            {
                GameObject otherCube = hit.collider.gameObject;

                if (otherCube.CompareTag("Box") && otherCube.GetComponent<BoxSystem>().boxColor == boxColor && speed <= 0.1f)
                {
                    Debug.Log("Cube collided with: " + otherCube.name);
                    Debug.DrawRay(transform.position, direction * raycastDistance, Color.red, 1.0f);

                    Destroy(this.gameObject, 0.2f);
                    Destroy(otherCube.gameObject, 0.2f);
                }
            }
        }
    }
    private void OnDestroy()
    {
        MainUI.Instance.UpdateCoins(MainUI.Instance.totalCoins += 1);
        MainUI.Instance.UpdateScore(MainUI.Instance.totalScore += 10);
    }
}

public enum BoxColor
{
    Red,
    Green, 
    Blue,
    Yellow,
    Black,
    Brown,
    Purple,
    White
}
