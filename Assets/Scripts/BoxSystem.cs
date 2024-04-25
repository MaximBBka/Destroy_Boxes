using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSystem : MonoBehaviour
{
    [SerializeField] BoxCollider boxColider;
    public BoxColor boxColor;
    private float speed = 0f;

    private void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            if (collision.collider.GetComponent<BoxSystem>())
            {
                if (collision.collider.GetComponent<BoxSystem>().boxColor == boxColor && speed == 0)
                {
                    Destroy(this.gameObject, 0.3f);
                    Destroy(collision.gameObject, 0.3f);
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
