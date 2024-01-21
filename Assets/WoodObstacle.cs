using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodObstacle : MonoBehaviour
{
    
    private GameObject colliderPlayerTwo;
    public GameObject playerTwo;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "ColliderPlayerTwo" && Input.GetKey("p"))
        {
        
            {
                 anim.SetBool("WoodMove", true);
                
            }
        }
        if (collision.gameObject.tag == "ColliderPlayerTwo" && Input.GetKeyUp("p"))
        {
             anim.SetBool("back", true);
        }
    }
}
