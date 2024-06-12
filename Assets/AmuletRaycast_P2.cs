using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P2 : MonoBehaviour
{
    public GameObject playerOne;
    //public AmuletControlls amuletScript;
    public bool P1Hit = false;
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
           
            if (hitinfo.collider.tag == "ColliderPlayerOne")
            {
                Debug.Log("PLAYER ONE HIT");
                P1Hit = true;



            }
           
           
        }
        else
        {
            //Debug.Log("HIt nothing");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 20f, Color.green );
            P1Hit = false;
        }
    }
}
