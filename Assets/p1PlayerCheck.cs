using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1PlayerCheck : MonoBehaviour
{
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ColliderPlayerTwo"))
        {
            playerManager.p1DistanceIs = true;
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("ColliderPlayerTwo"))
        {
            playerManager.p1DistanceIs = false;
        }
    }
}
