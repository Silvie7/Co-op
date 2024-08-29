using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneCollisionScript : MonoBehaviour
{
  
    [SerializeField] public GameObject playerTwo;
    private GameObject playerTwoCollider;
    public GameObject fusion;
    [SerializeField] public bool holdButtonP1 = false;
    public PlayerTwoCollisionScript script;
    [SerializeField] public bool holdButtonBoth;
    public float buttonCounterP1 = 0.0f;

  
    // Start is called before the first frame update
    void Start()
    {
        
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");


        fusion.SetActive(false); 
        
  

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            buttonCounterP1 += Time.deltaTime;

            if (buttonCounterP1 >= 1f)
            {
                holdButtonP1 = true;
                Debug.Log("Button e True");
                buttonCounterP1 = 0f;
            }  
        }
        if (Input.GetKeyUp("e"))
        {
            holdButtonP1 = false;
            Debug.Log("Button e False");
            buttonCounterP1 = 0f;
        }
     
        //{
        //    holdButtonP1 = true;
        //   Debug.Log("ButtonEP1");
        //}
        //else
        //{
        //    holdButtonP1 = false;
        //    //Debug.Log("ButtonEP1false");
        //}


        if (holdButtonP1 == true && script.holdButtonP2 == true)
        {
            holdButtonBoth = true;
        }
        else
        {
            holdButtonBoth = false;
        }

        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "playerTwoCollider" && holdButtonBoth == true)
        {
            if (playerTwo != null)
            {
                fusion.SetActive(true);
                playerTwo.SetActive(false);
                gameObject.SetActive(false);
                Debug.Log("true");
            }
        }
        
   
    }
       
    private void OnTriggerExit(Collider collision)
    {

    }

}
