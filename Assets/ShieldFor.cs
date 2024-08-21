using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFor : MonoBehaviour
{
    public bool shieldFor = false;

    public Transform enemyOne;
    public Transform enemyTwo;
     private AmuletRaycast_P2 amuletRaycast_P2;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {


        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
         {
            shieldFor = true;
            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
            ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

            Transform randomTarget = Random.value < 0.5f ? enemyOne : enemyTwo;

            shootTowardsPlayer.ChangeTarget(randomTarget);
                
            Vector3 directionToTarget = (randomTarget.position - projectileRb.position).normalized;
            projectileRb.velocity = directionToTarget * 5;
            enemyManager.ResetPrintedLog();
        }
        else
        {
            shieldFor = false;
        }

    }

}
