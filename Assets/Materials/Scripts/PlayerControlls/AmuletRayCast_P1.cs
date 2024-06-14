using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P1 : MonoBehaviour
{
    public GameObject playerTwo;
    public AmuletControlls amuletScript;
    public bool P2Hit = false;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    public bool target1Hit = false;
    public bool target2Hit = false;
    public bool target3Hit = false;
    public bool target4Hit = false;

    int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target1Hit = false;
        target2Hit = false;
        target3Hit = false;
        target4Hit = false;


       if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f))
        {
           // Debug.Log("Hit something");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red );
           
            
            if (hitinfo.collider.gameObject == target1)
            {
                target1Hit = true;
            }
            else if (hitinfo.collider.gameObject == target2)
            {
                target2Hit = true;
            }
            else if (hitinfo.collider.gameObject == target3)
            {
                target3Hit = true;
            }
            else if (hitinfo.collider.gameObject == target4)
            {
                target4Hit = true;
            }
            else if (hitinfo.collider.tag == "ColliderPlayerTwo")
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
