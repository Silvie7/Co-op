using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingBackLight1 : MonoBehaviour
{
 public GameObject light1;
    public void TriggerEvent1()
    {
        Debug.Log("event triggered");
       light1.SetActive(false);

    }
}
