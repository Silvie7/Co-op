using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersActions : MonoBehaviour
{
   public bool aimingBoth = false; //both aim at each other
   public bool bothPressX = false; //both are pressing x
   public GameObject shield; //shield for both that push the ball away
   public GameObject shieldForP1;
   public GameObject shieldForP2;
   public bool sameTargetChosen = false; //both players chose the same target
   public GameObject finalTarget; //stores the final target of both players here

   public bool chargingP1 = false;
   public bool chargingP2 = false;
   
   public bool stealingBall = false;

   public bool sameTarget = false;
   public bool shieldP2 = false; //shield only for p2 made by p1
   public bool shieldP1 = false; //shield only for p1 made by p2

   public AmuletRaycast_P2 p2Raycast;
   private AmuletRaycast_P1 p1Raycast;
   private TargetSelectorP1 targetSelectorP1;
   private TargetSelectorP2 targetSelectorP2;
   private EnemyManager enemyManager;
   private PlayerOneManager p1Energy; //player 1 manager script, takes energy info


    // Start is called before the first frame update
    void Start()
    {
        p2Raycast = FindObjectOfType<AmuletRaycast_P2>();
        p1Raycast = FindObjectOfType<AmuletRaycast_P1>();

        p1Energy = FindObjectOfType<PlayerOneManager>(); 
        targetSelectorP1 = FindObjectOfType<TargetSelectorP1>();
        targetSelectorP2 = FindObjectOfType<TargetSelectorP2>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //  SHIELD FOR BOTH PLAYERS

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
        
        if (p1Raycast.chosenTargetp1!= null && p2Raycast.chosenTarget!= null && p1Raycast.chosenTargetp1.name == p2Raycast.chosenTarget.name)
        {
            sameTarget = true;
        }
        else
        {
            sameTarget = false;
        }

        //TARGET SELECTION
        if (targetSelectorP1.hasBeenChosenP1 && targetSelectorP2.hasBeenChosenP2)
        {
            if(targetSelectorP1.chosenObjectP1 == targetSelectorP2.chosenObjectP2)
            {
                sameTargetChosen = true;
                finalTarget = targetSelectorP1.chosenObjectP1; //store the target both chose
            }
            if (enemyManager.nullTheTarget == true)
            {
                targetSelectorP1.hasBeenChosenP1 = false;
                targetSelectorP2.hasBeenChosenP2 = false;
                sameTargetChosen = false;
                finalTarget = null;
            }
        }

        // if (sameTarget == true)
        // {
        //     if (bothPressX == true )
        //     {
        //         shield.SetActive(true);
        //     }
        //     else
        //     {
        //         shield.SetActive(false);
        //     }
        // }

          

        //SHIELD FOR PROTECTING PLAYER TWO
        // If player one hits player two and presses square it sets shield bool to true
        if (p1Raycast.P2Hit == true && Input.GetButton("Square"))
        {
            shieldP2 = true;
           
        }
        else
        {
            shieldP2 = false;
        }

        //SHIELD FOR PROTECTING PLAYER ONE
         // If player two hits player one and presses q it activates
        if (p2Raycast.P1Hit == true && Input.GetKey("q"))
        {
            shieldP1 = true;
           
        }
        else
        {
            shieldP1 = false;
        }

        //CHARGING ENERGY P1 lvl 1
        if (p1Raycast.EnergyAmuletHitP1 == true && Input.GetButton("Triangle"))
        {
            Debug.Log("TRIANGLE");
            chargingP1 = true;
        }
        else
        {
            chargingP1 = false;
        }

        if (p2Raycast.EnergyAmuletHitP2 == true && Input.GetKeyDown("e"))
        {
            chargingP2 = true;
        }
        else
        {
            chargingP2 = false;
        }

        //Ball stealing
        if (p1Raycast.hitsBallColliderP1 == true && p2Raycast.hitsBallColliderP2 == true)
        {
            if (Input.GetKey("r") && Input.GetButton("R2"))
            {
                stealingBall = true;
                Debug.Log("STEAL");
            }

        }




    }
}
