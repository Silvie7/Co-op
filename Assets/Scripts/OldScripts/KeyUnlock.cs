using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlock : MonoBehaviour
{
    public GameObject key;
     public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Key")
        {
             anim.SetBool("opening", true);
        }
    }
}
