using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P1 : MonoBehaviour
{
    public GameObject playerTwo;
    public AmuletControlls amuletScript;
    public bool P2Hit = false;
    int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f))
        {
           // Debug.Log("Hit something");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red );
           
            if (hitinfo.collider.tag == "ColliderPlayerTwo")
            {
                Debug.Log("PLAYER TWO HIT");
                P2Hit = true;



            }
           
           
        }
        else
        {
            //Debug.Log("HIt nothing");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 20f, Color.green );
            P2Hit = false;
        }

        

        
    }
}
