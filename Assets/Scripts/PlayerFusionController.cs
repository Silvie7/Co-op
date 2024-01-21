using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFusionController : MonoBehaviour
{
        public GameObject playerOne;
       public GameObject playerTwo;
       private GameObject colliderPlayerOne;
       private GameObject colliderPlayerTwo;
        public GameObject fusion;
        public static bool holdButtonBoth;
         public float buttonCounterP1 = 0.0f;
         public float buttonCounterP2 = 0.0f;
         private bool holdButtonP1 = false;
         private bool holdButtonP2 = false;
         private bool fused = false;
         private bool canFuseP1 = true;
         private bool canFuseP2 = true;
         
         
         

    // Start is called before the first frame update
    void Start()
    {
    

        colliderPlayerOne = GameObject.FindGameObjectWithTag("ColliderPlayerOne");
        colliderPlayerTwo = GameObject.FindGameObjectWithTag("ColliderPlayerTwo");

        holdButtonBoth = false;

        fusion.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //counter for holding button P1
        if (Input.GetKey("e") && holdButtonP1 == false && canFuseP1)
        {
            buttonCounterP1 += Time.deltaTime;

            if (buttonCounterP1 >= 1f)
            {
                holdButtonP1 = true;
                buttonCounterP1 = 0f;
            }  
        }

        if (Input.GetKeyUp("e"))
        {
            holdButtonP1 = false;
            canFuseP1 = true;
            buttonCounterP1 = 0f;
        } 

        //counter for holding button P2
        if (Input.GetKey("r") && holdButtonP2 == false && canFuseP2)
        {
            buttonCounterP2 += Time.deltaTime;

            if (buttonCounterP2 >= 1f)
            {
                holdButtonP2 = true;
                buttonCounterP2 = 0f;
            }  
        }

        if (Input.GetKeyUp("r"))
        {
            holdButtonP2 = false;
            canFuseP2 = true;
            buttonCounterP2 = 0f;
        } 

        //holding both buttons for both players 
        if (holdButtonP1 == true && holdButtonP2 == true)
        {
            holdButtonBoth = true;
            canFuseP1 = false;
            canFuseP2 = false;
        }
        else
        {
            holdButtonBoth = false;
        }
        //checking if fusion is active and set players as child
        if (fusion.activeSelf == true)
        {
            
            playerOne.transform.parent = fusion.transform;
            playerTwo.transform.parent = fusion.transform;
            
           
        }
        if (fusion.activeSelf == true && holdButtonBoth == true)
        {
            fusion.SetActive(false);
            playerOne.transform.parent = null;
            playerTwo.transform.parent = null;
            playerOne.SetActive(true);
            playerTwo.SetActive(true);
            holdButtonBoth = false;
        }


    
       
        
        
        

    }

}
