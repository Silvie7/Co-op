using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    public Transform target; 

    private float shootForce = 10f; 

    // Start is called before the first frame update
    void Start()
    {
        {
            // Calculate the direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Shoot towards the target
        GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
        } 
        
        
          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}


