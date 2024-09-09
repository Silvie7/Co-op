using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P2 : MonoBehaviour
{
    public GameObject playerOne;
    //public AmuletControlls amuletScript;
    public bool P1Hit = false;
    int playerLayer;
    
    public bool targetChosen = false;
    public GameObject aimedTarget;
    public GameObject chosenTarget;

    
    public bool p2Key = false;

    private Target targetScript;

    public bool EnergyAmuletHitP2 = false;
    public bool hitsBallColliderP2 = false;

    

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
           
           if (hitinfo.collider != null)
           {
                if (hitinfo.collider.tag == "EnergyAmuletlvl1") //raycast hit amulet
                {
                    EnergyAmuletHitP2 = true;
                }

                if (hitinfo.collider.tag == "ColliderPlayerOne") //raycast hit player 1
                {
                    Debug.Log("PLAYER ONE HIT");
                    P1Hit = true;
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
