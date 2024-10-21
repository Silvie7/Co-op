using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    public Vector3 target;
    public Vector3 initialDirection; 
    public bool hasHitPlayer = false;

    public bool hasHitEnemy = false;

    private GameObject territoryE;
    private GameObject territoryP;

    public ProjectilePlayer projectilePlayer;
    public TurnsManager turnsManager;
    private PlayerManager playerManager;
  
    

    private float shootForce = 10f; 
    public Rigidbody rb;

    private float normalSpeed = 4f;
     public float slowSpeed = 1f;//spead of the ball

    private bool isInSlowZone = false;

    // Start is called before the first frame update
    void Start()
    {
      

        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialDirection * shootForce, ForceMode.Impulse);

        turnsManager = GameObject.Find("TurnsManager").GetComponent<TurnsManager>();
        playerManager = FindObjectOfType<PlayerManager>();





    }

    void FixedUpdate()
    {
         if (target!= null)
         {
            Vector3 directionToTarget = (target - transform.position).normalized;
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

    public void ChangeTarget(Vector3 newTarget)
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
        
        if (collision.gameObject.CompareTag("BigShield"))
        {
            playerManager.BigShieldEnergyLoss();
        }

        if (collision.gameObject.name == "ShieldForP1")
        {
            playerManager.P1ShieldEnergyLoss();
        }

        if (collision.gameObject.name == "ShieldForP2")
        {
            playerManager.P2ShieldEnergyLoss();
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


