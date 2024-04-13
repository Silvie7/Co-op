using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightTakingBack : MonoBehaviour
{
    
    public GameObject light1;
    public void TriggerEvent()
    {
        Debug.Log("event triggered");
       light1.SetActive(true);

    }
}
