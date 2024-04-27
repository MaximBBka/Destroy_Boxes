using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BoxMove>(out BoxMove box))
        {
            if (box.speed >= 2f)
            {
                MainUI.Instance.ShowPanelLose();
            }
        }
    }
}
