using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public bool eShieldHit = false;
    private AmuletRaycast_P2 amuletRaycast_P2;
   
    public Transform playerOne;
    public Transform playerTwo;
    public EnemyManager enemyManager;
    public CursorManager cursorManager;
    // Start is called before the first frame update
    void Start()
    {
        amuletRaycast_P2 = GameObject.FindObjectOfType<AmuletRaycast_P2>();
      
    }

    // Update is called once per frame
    
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
    {
            cursorManager.cursorFreeze = false;

            if (enemyManager != null)
            {
               
                StartCoroutine(enemyManager.MoveEnemyBack());
            }

            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
        ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

        Transform randomTarget = Random.value < 0.5f ? playerOne : playerTwo;

        shootTowardsPlayer.ChangeTarget(randomTarget);
        
        Vector3 directionToTarget = (randomTarget.position - projectileRb.position).normalized;
        projectileRb.velocity = directionToTarget * 5;
        
        // enemyManager.ActivateShieldForCube();
    }
    // else
    // {
    //   eShieldHit = false;
    // }
  }
}
