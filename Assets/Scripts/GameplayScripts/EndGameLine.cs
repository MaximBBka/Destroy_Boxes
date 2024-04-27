using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameLine : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<BoxMove>(out BoxMove box))
        {
            if (box.speed <= 0)
            {
                MainUI.Instance.ShowPanelLose();
            }
        }
    }
}
