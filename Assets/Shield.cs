using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float deflectionForce = 10f;
    public Transform targetPosition;
    private AmuletRaycast_P2 amuletRaycast_P2;
    public bool shieldHit = false;
    public EnemyManager enemyManager;

    void Start ()
    {
      amuletRaycast_P2 = GameObject.FindObjectOfType<AmuletRaycast_P2>();
       enemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
    {
        shieldHit = true;
        Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
        ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

        shootTowardsPlayer.ChangeTarget(amuletRaycast_P2.chosenTarget.transform);

        //Vector3 deflectionDirection = Vector3.Reflect(projectileRb.velocity, transform.forward);

        //Vector3 targetDirection = (targetPosition.position - projectileRb.position).normalized;

        //Vector3 finalDirection = Vector3.Lerp(deflectionDirection, targetDirection, 5f);
        
        Vector3 directionToTarget = (amuletRaycast_P2.chosenTarget.transform.position - projectileRb.position).normalized;
        projectileRb.velocity = directionToTarget * 5;
       // projectileRb.AddForce(directionToTarget * deflectionForce, ForceMode.Impulse);
       enemyManager.ResetPrintedLog();
    }
    else
    {
      shieldHit = false;
    }
  }
}
