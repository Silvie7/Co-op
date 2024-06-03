using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoStats : MonoBehaviour
{
    public float energy = 0f;
    private AmuletRayCast_Controller scriptRaycast;
    public GameObject playerTwoShield;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptRaycast = FindObjectOfType<AmuletRayCast_Controller>();
        playerTwoShield.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //charging energy
        if (scriptRaycast.P2Hit == true && Input.GetButton("X"))
        {
            energy = 5f;
            Debug.Log("HITYESSS");
        }

        if (scriptRaycast.P2Hit == true && Input.GetButton("Circle"))
        {
            playerTwoShield.SetActive(true);

        }
        else
        {
            playerTwoShield.SetActive(false);
        }
      
    }
}
