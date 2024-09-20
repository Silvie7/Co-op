using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldForE1 : MonoBehaviour
{
    public bool e1ShieldHit = false;
    public EnemyManager enemyManager;
    public Transform playerOne;
    public Transform playerTwo;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<ShootTowardsPlayer>() != null)
        {
            e1ShieldHit = true;
            Debug.Log("E1HIT");
            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();

            Transform randomTarget = Random.value < 0.5f ? playerOne : playerTwo;
            ShootTowardsPlayer shootTowardsPlayer = collision.gameObject.GetComponent<ShootTowardsPlayer>();
            shootTowardsPlayer.ChangeTarget(randomTarget);

            Vector3 directionToTarget = (randomTarget.position - projectileRb.position).normalized;
            projectileRb.velocity = directionToTarget * 5;
            enemyManager.ResetPrintedLog();
        }
        else
        {
            e1ShieldHit = false;
        }
    }
}
