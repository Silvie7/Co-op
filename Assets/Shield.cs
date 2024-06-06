using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float deflectionForce = 10f;
    public Transform targetPosition;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
    {
        Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();

        Vector3 deflectionDirection = Vector3.Reflect(projectileRb.velocity, transform.forward);

        Vector3 targetDirection = (targetPosition.position - projectileRb.position).normalized;

        Vector3 finalDirection = Vector3.Lerp(deflectionDirection, targetDirection, 5f);

        projectileRb.AddForce(finalDirection * deflectionForce, ForceMode.Impulse);
    }
  }
}
