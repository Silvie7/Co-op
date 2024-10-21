using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    public GameObject p1Shield; //shield for p1
    public GameObject p2Shield; //shield for p2
    public GameObject bigShield; //big shield they players have together

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject shieldCenter;
    public float pushedSpeed = 2f; //the speed of pushed object

    public ChargingObject chargingObject;
    public bool shieldHit = false;
    public bool p1ChargeDistanceIs = false;
    public bool p2ChargeDistanceIs = false;
    public bool p1DistanceIs = false;

    public float energyCharged = 2;

    public float player1Energy = 10f;
    public float player2Energy = 10f;

    public float allowedDistance;
    public float xOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HandleShieldCenter();

        if (player1Energy != 0 || player2Energy != 0)
        {
            //BIG SHIELD ACTIVATION
            if (Input.GetKey("x") && Input.GetButton("X"))
            {

                bigShield.SetActive(true);  //activate big shield
            }
            else
            {
                bigShield.SetActive(false); //deactivate big shield
            }
        }
        else
        {
            bigShield.SetActive(false);
        }

        if (player1Energy != 0)
        {
            //SMALL SHIELD ACTIVATION FOR P2
            if (Input.GetButton("Square"))
            {
                p1Shield.SetActive(true);
            }
            else
            {
                p1Shield.SetActive(false);
            }

            //PUSH PLAYER TWO (FOR P1)
            if (p1DistanceIs == true && Input.GetButton("Circle"))
            {
                MovePlayer2();
            }
        }
        else
        {
            p1Shield.SetActive(false);
        }

        if (player2Energy != 0)
        {
            //SMALL SHIELD ACTIVATION FOR P1
            if (Input.GetKey("q"))
            {
                p2Shield.SetActive(true);

            }
            else
            {
                p2Shield.SetActive(false);
            }

            //PUSH PLAYER ONE (FRO P2)
            {
                if (p1DistanceIs == true && Input.GetKey("o"))
                {
                    MovePlayer1();
                }
            }
        }
        else
        {
            p2Shield.SetActive(false);
        }

        //CHARGING ENERGY P1
        if (p1ChargeDistanceIs == true && Input.GetButton("Triangle"))
        {
            if (!chargingObject.isOnCooldown)
            {
                player1Energy += energyCharged;
                chargingObject.StartCoroutine(chargingObject.ChargingCooldown(chargingObject.cooldownTime));
            }
        }

        //CHARGING ENERGY P2
        if (p2ChargeDistanceIs == true && Input.GetKeyDown("e"))
        {
            if (!chargingObject.isOnCooldown)
            {
                player2Energy += energyCharged;
                chargingObject.StartCoroutine(chargingObject.ChargingCooldown(chargingObject.cooldownTime));
            }

        }
    }

    void MovePlayer2()
    {

        // Get the current position of playerOne and playerTwo
        Vector3 playerOnePosition = playerOne.transform.position;
        Vector3 playerTwoPosition = playerTwo.transform.position;

        // Calculate the direction from playerOne to playerTwo
        Vector3 pushDirection = (playerTwoPosition - playerOnePosition).normalized;

        // Determine how far to push playerTwo along the Z-axis
        // multiply the direction by the pushedSpeed and the desired distance
        float pushDistance = 3.0f; //how far away the player is being pushed
        Vector3 pushForce = pushDirection * pushedSpeed * pushDistance;

        // Apply the force to playerTwo's Rigidbody
        playerTwo.GetComponent<Rigidbody>().AddForce(pushForce, ForceMode.Impulse);


    }

    void MovePlayer1()
    {
        //current position of player one and two
        Vector3 playerOnePosition = playerOne.transform.position;
        Vector3 playerTwoPosition = playerTwo.transform.position;

        //calculate the direction from player one to two
        Vector3 pushDirection = (playerOnePosition - playerTwoPosition).normalized;

        //how far to push the player
        float pushDistance = 3.0f;
        Vector3 pushForce = pushDirection * pushedSpeed * pushDistance;

        //apply the force to players one Rigidbody
        playerOne.GetComponent<Rigidbody>().AddForce(pushForce, ForceMode.Impulse);
    }

    public void BigShieldEnergyLoss()
    {
        player1Energy = Mathf.Max(0, player1Energy - 4);
        player2Energy = Mathf.Max(0, player2Energy - 4);
    }
   
   public void P1ShieldEnergyLoss()
    {
        player1Energy = Mathf.Max(0, player1Energy - 2);
    }
    public void P2ShieldEnergyLoss()
    {
        player2Energy = Mathf.Max(0, player2Energy - 4);
    }

    void HandleShieldCenter()
    {
        var centerPositionPlayers = Vector3.Lerp(playerOne.transform.position, playerTwo.transform.position, 0.5f);

        
        centerPositionPlayers.x += xOffset;
        shieldCenter.transform.position = centerPositionPlayers;

        if (p1ChargeDistanceIs == true && Vector3.Distance(playerOne.transform.position, playerTwo.transform.position) > allowedDistance)
        {
            shieldCenter.SetActive(false);
        }
        else
        {
            shieldCenter.SetActive(true);
        }
    }
}
