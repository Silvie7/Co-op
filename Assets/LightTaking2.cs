using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTaking2 : MonoBehaviour
{
   public GameObject light2;
    public void TriggerEvent2()
    {
        Debug.Log("event triggered");
       light2.SetActive(true);

    }
}
