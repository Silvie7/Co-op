using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsEnemy : MonoBehaviour
{
    public Transform target; 

    private GameObject territoryP;

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
        territoryP = GameObject.Find("TerritoryPlayers"); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ColliderEnemyOne") || collision.gameObject.CompareTag("ColliderEnemyTwo")) 
        {
            // Scale up the TerritoryE object
            territoryP.transform.localScale += new Vector3(1, 0, 0); 
            Destroy(gameObject); 
        }
    }
}
