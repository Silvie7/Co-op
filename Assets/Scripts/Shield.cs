using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float deflectionForce = 10f;
    public Transform targetPosition;
    public PlayerManager playerManager;
    
    public CursorManager cursorManager;

    void Start ()
    {
      
    }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
    {
        playerManager.shieldHit = true;
        Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
        ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

        shootTowardsPlayer.ChangeTarget(cursorManager.target.transform);
        
        Vector3 directionToTarget = (cursorManager.target.transform.position - projectileRb.position).normalized;
        projectileRb.velocity = directionToTarget * 5;
    }
   
  }
}
