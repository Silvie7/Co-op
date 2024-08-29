using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlayer : MonoBehaviour
{
    public GameObject playerProjectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void CreateNewObjectForPlayer()
        {
            GameObject playerProjectile = Instantiate(playerProjectilePrefab, transform.position, Quaternion.identity);
            Debug.Log("CREATED PROJECTILE");

            // Make the projectile stay in place
            Rigidbody rb = playerProjectile.GetComponent<Rigidbody>();
            if (rb!= null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
}
