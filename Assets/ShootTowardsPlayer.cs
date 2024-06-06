using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    public Transform target; 

    private GameObject territoryE;

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
        territoryE = GameObject.Find("TerritoryEnemies"); 
        
       

        
          
        
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


