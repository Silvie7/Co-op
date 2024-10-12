using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject p1Shield; //shield for p1
    public GameObject p2Shield; //shield for p2
    public GameObject bigShield; //big shield they players have together

    public GameObject playerOne;
    public GameObject playerTwo;
    public float pushedSpeed = 2f; //the speed of pushed object

    public ChargingObject chargingObject;
    public bool shieldHit = false;
    public bool p1ChargeDistanceIs = false;
    public bool p2ChargeDistanceIs = false;
    public bool p1DistanceIs = false;

    public float player1Energy = 10f;
    public float player2Energy = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

        //SMALL SHIELD ACTIVATION FOR P1
        if (Input.GetKey("q"))
        {
            p2Shield.SetActive(true);

        }
        else
        {
            p1Shield.SetActive(false);
        }

        //SMALL SHIELD ACTIVATION FOR P2
        if (Input.GetButton("Square"))
        {
            p1Shield.SetActive(true);
        }
        else
        {
            p2Shield.SetActive(false);
        }

        if (p1DistanceIs == true && Input.GetButton("Circle"))
        {
            MovePlayer2();
        }

        //CHARGING ENERGY P1
        if (p1ChargeDistanceIs == true && Input.GetButton("Triangle"))
        {
            if (!chargingObject.isOnCooldown)
            {
                player1Energy += 2;
                chargingObject.StartCoroutine(chargingObject.ChargingCooldown(chargingObject.cooldownTime));
            }
        }

        //CHARGING ENERGY P2
        if (p2ChargeDistanceIs == true && Input.GetKeyDown("e"))
        {
            if (!chargingObject.isOnCooldown)
            {
                player2Energy += 2;
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
        // Here, we multiply the direction by the pushedSpeed and the desired distance
        float pushDistance = 3.0f; // Change this value to set how far away you want to push playerTwo
        Vector3 pushForce = pushDirection * pushedSpeed * pushDistance;

        // Apply the force to playerTwo's Rigidbody
        playerTwo.GetComponent<Rigidbody>().AddForce(pushForce, ForceMode.Impulse);


    }
}
