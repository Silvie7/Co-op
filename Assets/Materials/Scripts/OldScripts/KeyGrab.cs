using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrab : MonoBehaviour
{ private GameObject colliderPlayerOne;
    public GameObject playerOne;
    public GameObject Key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "ColliderPlayerOne" && Input.GetKey("q"))
        {
            Key.transform.parent = playerOne.transform;
           
        }
    }
}
