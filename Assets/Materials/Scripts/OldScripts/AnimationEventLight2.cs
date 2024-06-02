using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventLight2 : MonoBehaviour
{
    public GameObject light2;
    public void TriggerEvent()
    {
        Debug.Log("event triggered");
       light2.SetActive(false);

    }
}
