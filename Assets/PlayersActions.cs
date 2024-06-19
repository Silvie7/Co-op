using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersActions : MonoBehaviour
{
   public bool aimingBoth = false; //both aim at each other
   public bool bothPressX = false; //both are pressing x
   public GameObject shield; //shield for both that push the ball away
   public GameObject shieldForP2; //shield that only protects player 2 (don't know what else it does for now)

   public bool sameTarget = false;

   private AmuletRaycast_P2 p2Raycast;
   private AmuletRaycast_P1 p1Raycast;
   private PlayerOneManager p1Energy; //player 1 manager script, takes energy info


    // Start is called before the first frame update
    void Start()
    {
        p2Raycast = FindObjectOfType<AmuletRaycast_P2>();
        p1Raycast = FindObjectOfType<AmuletRaycast_P1>();

        p1Energy = FindObjectOfType<PlayerOneManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //  SHIELD

        //both players pressing X
        if (Input.GetButton("X") && Input.GetKey("x"))
        {
            bothPressX = true;
        }
        // they are not pressing X
        else
        {
            bothPressX = false;
        }

        //Both players are aiming raycast at each other
         if (p2Raycast.P1Hit == true && p1Raycast.P2Hit == true)
        {
            Debug.Log("Both Are Aiming");
            aimingBoth = true;
        }
        //if not then nothing
        else
        {
            aimingBoth = false;
        }

        //If both press X then activate the shield
        if (bothPressX == true && bothPressX == true)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
        

        //SHIELD FOR PROTECTING PLAYER TWO
        // If player one hits player two and presses square it activates
        if (p1Raycast.P2Hit == true && Input.GetButton("Square"))
        {
            shieldForP2.SetActive(true);
        }
        else
        {
            shieldForP2.SetActive(false);
        }


        // if (p2Raycast.P1Hit == true && Input.GetKey("o"))
        // {
        //     p1Energy.energy = 5f;   
        // }
        
        if (p1Raycast.chosenTargetp1!= null && p2Raycast.chosenTarget!= null && p1Raycast.chosenTargetp1.name == p2Raycast.chosenTarget.name)
        {
            sameTarget = true;
        }
        else
        {
            sameTarget = false;
        }
    }
}
