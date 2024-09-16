using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float deflectionForce = 10f;
    public Transform targetPosition;
    private PlayersActions playersActions;
    public bool shieldHit = false;
    public EnemyManager enemyManager;

    void Start ()
    {
      playersActions = GameObject.FindObjectOfType<PlayersActions>();
      enemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
    {
        shieldHit = true;
        Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
        ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

        shootTowardsPlayer.ChangeTarget(playersActions.finalTarget.transform);
        
        Vector3 directionToTarget = (playersActions.finalTarget.transform.position - projectileRb.position).normalized;
        projectileRb.velocity = directionToTarget * 5;
       enemyManager.ResetPrintedLog();
    }
    else
    {
      shieldHit = false;
    }
  }
}
