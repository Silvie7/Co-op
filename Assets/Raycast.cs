using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            Debug.Log("Hit something");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red );
           
            if (hitinfo.collider.tag == "ColliderPlayerOne")
            {
                Debug.Log("PLAYER ONE HIT");
                playerOne.SetActive(false);

            }
            
            if (hitinfo.collider.tag == "ColliderPlayerTwo")
            {
                playerTwo.SetActive(false);
            }
             

        }
        else
        {
            Debug.Log("HIt nothing");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 20f, Color.green );
        }
     
    }
}
