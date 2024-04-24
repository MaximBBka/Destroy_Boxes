using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSystem : MonoBehaviour
{
    [SerializeField] BoxCollider boxColider;
    public BoxColor boxColor;
    private float speed = 0f;
    private float timerAbility;

    private void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        if (MainUI.Instance.IsAbility && MainUI.Instance.totalAbility > 0) 
        {
            DeleteBox();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            if (collision.collider.GetComponent<BoxSystem>())
            {
                if (collision.collider.GetComponent<BoxSystem>().boxColor == boxColor && speed == 0)
                {
                    MainUI.Instance.UpdateCoins(MainUI.Instance.totalCoins += 1);
                    MainUI.Instance.UpdateScore(MainUI.Instance.totalScore += 10); 
                    Destroy(this.gameObject, 0.3f);
                    Destroy(collision.gameObject, 0.3f);
                }
            }
        }
        if (collision.collider.CompareTag("Delete"))
        {
            MainUI.Instance.UpdateCoins(MainUI.Instance.totalCoins += 1);
            MainUI.Instance.UpdateScore(MainUI.Instance.totalScore += 10);
            Destroy(gameObject);
        }
    }
    private void DeleteBox()
    {
        if (transform.position.y < 2f)
        {
            boxColider.isTrigger = true;
            timerAbility += Time.deltaTime;
            if (timerAbility > 1f) 
            {
                boxColider.isTrigger = false;
                MainUI.Instance.DisableAbility();
            }           
        }
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
