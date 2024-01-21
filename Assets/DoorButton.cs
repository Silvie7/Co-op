using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    private GameObject colliderPlayerOne;
    private GameObject colliderPlayerTwo;
    public GameObject playerOne;
    public GameObject playerTwo;
    public Animator anim;
    public GameObject wire;
    
    // Start is called before the first frame update
    void Start()
    {
        colliderPlayerOne = GameObject.FindGameObjectWithTag("ColliderPlayerOne");
        colliderPlayerTwo = GameObject.FindGameObjectWithTag("ColliderPlayerTwo");
    }

    // Update is called once per frame
      private void OnTriggerStay(Collider collision)
    {
        if (wire.activeSelf == true)
        {
            if (collision.gameObject.tag == "ColliderPlayerTwo" && Input.GetKey("p")|| collision.gameObject.tag == "ColliderPlayerOne" && Input.GetKey("q"))
            {
                 anim.SetBool("DoorOpen", true);
                
            }
        }
    }
}
