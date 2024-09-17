using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldForE2 : MonoBehaviour
{
    public bool e2ShieldHit = false;
    public EnemyManager enemyManager;
    public Transform playerOne;
    public Transform playerTwo;
    public ShootTowardsPlayer shootTowardsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        shootTowardsPlayer = GameObject.FindObjectOfType<ShootTowardsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<ShootTowardsPlayer>()!= null)
        {
            e2ShieldHit = true;
            Rigidbody projectileRb = collision.gameObject.GetComponent<Rigidbody>();

            Transform randomTarget = Random.value < 0.5f ? playerOne : playerTwo;

            shootTowardsPlayer.ChangeTarget(randomTarget);

            Vector3 directionToTarget = (randomTarget.position - projectileRb.position).normalized;
            projectileRb.velocity = directionToTarget * 5;
            enemyManager.ResetPrintedLog();
        }
        else
        {
            e2ShieldHit = false;
        }
    }
}
