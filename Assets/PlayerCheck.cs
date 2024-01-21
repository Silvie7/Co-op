using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject.FindGameObjectWithTag("ColliderPlayerOne");
       GameObject.FindGameObjectWithTag("ColliderPlayerTwo");
    }

    
  private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ColliderPlayerTwo")
        {
           Debug.Log("DESTROY");
        }
    }
}
