using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersActions : MonoBehaviour
{
   public bool aimingBoth = false;

   private AmuletRaycast_P2 p2Raycast;
   private AmuletRayCast_P1 p1Raycast;
    // Start is called before the first frame update
    void Start()
    {
        p2Raycast = GameObject.Find("P2Raycast").GetComponent<AmuletRaycast_P2>();
        p1Raycast = GameObject.Find("P1Raycast").GetComponent<AmuletRayCast_P1>();
    }

    // Update is called once per frame
    void Update()
    {
        //Both players are aiming raycast at each other
         if (p2Raycast.P1Hit == true && p1Raycast.P2Hit == true)
        {
            Debug.Log("Both Are Aiming");
            aimingBoth = true;
        }
        else
        {
            aimingBoth = false;
        }

        //if (aimingBoth == true && )
    }
}
