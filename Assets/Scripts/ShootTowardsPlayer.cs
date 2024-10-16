using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 initialDirection; 
    public bool hasHitPlayer = false;

    public bool hasHitEnemy = false;

    private GameObject territoryE;
    private GameObject territoryP;

    public ProjectilePlayer projectilePlayer;
    public TurnsManager turnsManager;
  
    

    private float shootForce = 10f; 
    public Rigidbody rb;

    private float normalSpeed = 4f;
     public float slowSpeed = 1f;//spead of the ball

    private bool isInSlowZone = false;

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
         territoryP = GameObject.Find("TerritoryPlayers"); 

        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialDirection * shootForce, ForceMode.Impulse);

        turnsManager = GameObject.Find("TurnsManager").GetComponent<TurnsManager>();
        
      

           
        
    }

    void FixedUpdate()
    {
         if (target!= null)
         {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float currentSpeed = isInSlowZone ? slowSpeed : normalSpeed;
            rb.velocity = directionToTarget * currentSpeed;
            
         }

        // // if (pActionScript.stealingBall == true)
        // // {
        // //    ChangeTarget(ballPosition.transform);
        // //    Vector3 directionToTarget = (ballPosition.transform.position - rb.position).normalized;
        // //     rb.velocity = directionToTarget * 5;
        // //     enemyManager.ResetPrintedLog();
        // //     pActionScript.stealingBall = false;  
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
            hasHitPlayer = true;
            turnsManager.playerHit = true;
            Debug.Log("shoot towars true");
            // Scale up the TerritoryE object
            // territoryE.transform.localScale += new Vector3(0.5f, 0, 0); 
            Destroy(gameObject); 
        }
        else
        {
            hasHitPlayer = false;
        }

        if (collision.gameObject.CompareTag("ColliderEnemyOne") || collision.gameObject.CompareTag("ColliderEnemyTwo")) 
        {
            hasHitEnemy = true;
            //Destroy(gameObject);
        }    
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SlowZone"))
        {
            isInSlowZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SlowZone"))
        {
            isInSlowZone = false;
        }
    }
    
   
    
}


