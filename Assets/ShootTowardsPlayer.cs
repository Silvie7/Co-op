using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 initialDirection; 

    private GameObject territoryE;

    private float shootForce = 10f; 
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // {
        //     // Calculate the direction towards the target
        // Vector3 direction = (target.position - transform.position).normalized;

        // // Shoot towards the target
        // GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
        // } 
         territoryE = GameObject.Find("TerritoryEnemies"); 

        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialDirection * shootForce, ForceMode.Impulse);

           
        
    }

    void FixedUpdate()
    {
         if (target!= null)
         {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            rb.velocity = directionToTarget * 5f;
            // transform.position = Vector3.MoveTowards(transform.position, target.position, 10f * Time.deltaTime);
             //transform.rotation = Quaternion.LookRotation(initialDirection);
         }

        // if (target!= null)
        // {
        //     Vector3 direction = (target.position - transform.position).normalized;
        //     rb.velocity = direction * shootForce;
        // }
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ColliderPlayerOne") || collision.gameObject.CompareTag("ColliderPlayerTwo")) 
        {
            // Scale up the TerritoryE object
            territoryE.transform.localScale += new Vector3(1, 0, 0); 
            Destroy(gameObject); 
        }
    }
    
}


