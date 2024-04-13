using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireDiscconect2 : MonoBehaviour
{
     public GameObject playerOne;
       public GameObject playerTwo;
       private GameObject colliderPlayerOne;
       private GameObject colliderPlayerTwo;
       public GameObject  wireConnected;
       public GameObject wire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.tag == "ColliderPlayerTwo" && Input.GetKey("p")|| collision.gameObject.tag == "ColliderPlayerOne" && Input.GetKey("q"))
        {
            wireConnected.SetActive(true);
            wire.SetActive(false);
        }
    }
}
