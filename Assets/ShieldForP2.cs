using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldForP2: MonoBehaviour
{
    public bool shieldForP2 = false;

    public Transform enemyOne;
    public Transform enemyTwo;
     private AmuletRaycast_P2 amuletRaycast_P2;
  
    public PlayerManager playerManager;
    public CursorManager cursorManager;


    // Start is called before the first frame update
    void Start()
    {


        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
         {
            playerManager.shieldHit = true;
            cursorManager.canSelect = true;
            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
            ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

            Transform randomTarget = Random.value < 0.5f ? enemyOne : enemyTwo;

            cursorManager.target = randomTarget.gameObject;
            
            shootTowardsPlayer.ChangeTarget(randomTarget);
                
            Vector3 directionToTarget = (randomTarget.position - projectileRb.position).normalized;
            projectileRb.velocity = directionToTarget * 5;
          
        }
        // // else
        // // {
        // //     shieldFor = false;
        // }s

    }

}
