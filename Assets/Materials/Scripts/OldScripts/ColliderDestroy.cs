using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroy : MonoBehaviour
{
    private GameObject colliderPlayerOne;
    private GameObject colliderPlayerTwo;
    public GameObject playerOne;
    public GameObject playerTwo;
    // Start is called before the first frame update
    void Start()
    {
        colliderPlayerOne = GameObject.FindGameObjectWithTag("ColliderPlayerOne");
        colliderPlayerTwo = GameObject.FindGameObjectWithTag("ColliderPlayerTwo");
    }

    // Update is called once per frame
   private void OnTriggerStay(Collider collision)
    {
         if (collision.gameObject.tag == "ColliderPlayerTwo")
        {
            if (playerTwo != null) 
            {
                playerTwo.SetActive(false);
            }
        }

          if (collision.gameObject.tag == "ColliderPlayerOne")
        {
            if (playerOne != null) 
            {
                playerOne.SetActive(false);
            }
        }
    }
}
