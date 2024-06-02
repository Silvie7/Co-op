using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoStats : MonoBehaviour
{
    public float energy = 0f;
    private AmuletRayCast_Controller scriptRaycast;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptRaycast = FindObjectOfType<AmuletRayCast_Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptRaycast.P2Hit == true)
        {
            energy = 5f;
            Debug.Log("HITYESSS");
        }
      
    }
}
