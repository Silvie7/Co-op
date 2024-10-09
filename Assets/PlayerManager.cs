using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject p1Shield;
    public GameObject p2Shield;
    public GameObject bigShield;
    public ChargingObject chargingObject;
    public bool shieldHit = false;
    public bool p1ChargeDistanceIs = false;
    public bool p2ChargeDistanceIs = false;

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
}
