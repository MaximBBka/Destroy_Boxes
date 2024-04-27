using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayBoxes;
    [SerializeField] public Transform[] arraySpawnPoints;
    [SerializeField] private float timerSpawnBox;
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hand>(out Hand hand))
        {
            Rigidbody Box = Instantiate(arrayBoxes[Random.Range(0, arrayBoxes.Length)], hand.BoxTarget).GetComponent<Rigidbody>();
            hand.SetBox(Box);
            hand.SetTarget(arraySpawnPoints[Random.Range(0, arraySpawnPoints.Length)]);
        }
    }
}
