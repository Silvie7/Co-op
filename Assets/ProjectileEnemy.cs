using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject prefab;
    public Transform player1;
    public Transform player2;

    public bool projectileReady = false;

    private Transform targetPlayer;

    public void PrepareProjectile()
    {
        projectileReady = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateNewObject();
    }

    // Update is called once per frame
    public void CreateNewObject()
    {
        
        {
            GameObject newObject = Instantiate(prefab, transform.position, transform.rotation);

            targetPlayer = Random.value > 0.5? player1 : player2;

            newObject.GetComponent<ShootTowardsPlayer>().target = targetPlayer;

        }
        
    }

     public void TakeTurn()
    {
        PrepareProjectile();
    }

    
}
