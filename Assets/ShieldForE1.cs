using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldForE1 : MonoBehaviour
{
    public bool e1ShieldHit = false;
    
    public Transform playerOne;
    public Transform playerTwo;

    public EnemyManager enemyManager;
    public CursorManager cursorManager;

    public GameObject playerField; //the floor object


    public Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<ShootTowardsPlayer>() != null)
        {
            cursorManager.cursorFreeze = false;

            if (enemyManager != null)
            {
                StartCoroutine(enemyManager.MoveEnemyBack());
            }

            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();
            ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();

            randomPosition = GetRandomPositionOnField();

            shootTowardsPlayer.ChangeTarget(randomPosition);

            Vector3 directionToTarget = (randomPosition - projectileRb.position).normalized;
            projectileRb.velocity = directionToTarget * 5;

        }
    }

    Vector3 GetRandomPositionOnField()
    {
        //Get the collider of the player field
        var fieldCollider = playerField.GetComponent<Collider>();

        //get bounds of the players field collider
        Bounds bounds = fieldCollider.bounds;

        //Generate random X and X positions within the bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        //keep the Y position on the floor level
        float yPosition = bounds.min.y;

        return new Vector3(randomX, yPosition, randomZ);


    }
}
