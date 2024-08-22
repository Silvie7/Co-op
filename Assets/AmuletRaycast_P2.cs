using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P2 : MonoBehaviour
{
    public GameObject playerOne;
    //public AmuletControlls amuletScript;
    public bool P1Hit = false;
    int playerLayer;

    public GameObject target1; 
    public GameObject target2; 
    public GameObject target3; 
    public GameObject target4; 

    public bool target1Hit = false;
    public bool target2Hit = false;
    public bool target3Hit = false;
    public bool target4Hit = false;

    public bool targetChosen = false;
    public GameObject aimedTarget;
    public GameObject chosenTarget;

    
    public bool p2Key = false;

    private Target targetScript;

    public bool EnergyAmuletHitP2 = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // target1Hit = false;
        // target2Hit = false;
        // target3Hit = false;
        // target4Hit = false;

       if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f))
        {
           // Debug.Log("Hit something");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red );
           
           if (hitinfo.collider != null)
           {
                if (hitinfo.collider.tag == "EnergyAmuletlvl1")
                {
                    EnergyAmuletHitP2 = true;
                }

                if (hitinfo.collider.tag == "ColliderPlayerOne")
                {
                    Debug.Log("PLAYER ONE HIT");
                    P1Hit = true;
                }
                 else if (hitinfo.collider.gameObject == target1 || hitinfo.collider.gameObject == target2 || hitinfo.collider.gameObject == target3 || hitinfo.collider.gameObject == target4)
                {
                    //set the aimedTarget variable to the object that was hit
                    aimedTarget = hitinfo.collider.gameObject;

                    targetScript = aimedTarget.GetComponent<Target>();

                    if (targetScript != null)
                    {
                        targetScript.player2Hit = true;
                    }
                    
                    if (Input.GetKey("o"))
                    {
                        p2Key = true;
                        chosenTarget = hitinfo.collider.gameObject;
                    }
                    else 
                    {
                        p2Key = false;
                    }
                }
           }  
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
            //Reset the aimedTarget variable if the raycast didn't hit anything
            aimedTarget = null;
            if (targetScript != null)
            {
                targetScript.player2Hit = false;
            }
           P1Hit = false;
           EnergyAmuletHitP2 = false;
           
        }
       
    }
}
