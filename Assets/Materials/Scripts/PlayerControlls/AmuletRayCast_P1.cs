using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P1 : MonoBehaviour
{
    public GameObject playerTwo;
    //public AmuletControlls amuletScript;
    public bool P2Hit = false;
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
    public GameObject aimedTargetp1;
    public GameObject chosenTargetp1;

    public bool p1Key = false;

    public bool EnergyAmuletHit = false;
    
    private Target targetScript;

    

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
                //its charging amulet lvl 1
                if (hitinfo.collider.tag == "EnergyAmuletlvl1")
                {
                    Debug.Log("Energy Amulet Hit");
                    EnergyAmuletHit = true;
                }
                if (hitinfo.collider.tag == "ColliderPlayerTwo")
                {
                    Debug.Log("PLAYER TWO HIT");
                    P2Hit = true;
                }
                 else if (hitinfo.collider.gameObject == target1 || hitinfo.collider.gameObject == target2 || hitinfo.collider.gameObject == target3 || hitinfo.collider.gameObject == target4)
                {
                    //set the aimedTarget variable to the object that was hit
                    aimedTargetp1 = hitinfo.collider.gameObject;

                    targetScript = aimedTargetp1.GetComponent<Target>();

                    if (targetScript != null)
                    {
                        targetScript.player1Hit = true;
                    }
                    
                    if (Input.GetButton("Circle"))
                    {
                        p1Key = true;
                        chosenTargetp1 = hitinfo.collider.gameObject;
                    }
                    else 
                    {
                        p1Key = false;
                    }
                }
           }  
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
            //Reset the aimedTarget variable if the raycast didn't hit anything
            aimedTargetp1 = null;
            if (targetScript != null)
            {
                targetScript.player1Hit = false;
            }
           
           
        }
       
    }
}
