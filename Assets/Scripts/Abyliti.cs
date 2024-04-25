using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Abyliti : MonoBehaviour
{
    [SerializeField] private List<GameObject> boxes = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxes.Add(other.gameObject);
        }
    }
    public void DeleteBox()
    {
        MainUI.Instance.totalAbility -= 1;
        for (int i = 0; i < boxes.Count; i++)
        {
            if (MainUI.Instance.totalAbility > 0)
            {
                Destroy(boxes[i]);
                
            }
        }
        boxes.Clear();
    }
}
