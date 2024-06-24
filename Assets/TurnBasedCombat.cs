using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombat : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();

    private bool isPlayerTurn = false;

    public ShootTowardsPlayer hitEnemy;
    private GameObject territoryP;

    private ShootTowardsPlayer shootTowardsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        territoryP = GameObject.Find("TerritoryPlayers"); 

        StartCoroutine(TrunCycle());
    }

    IEnumerator TrunCycle()
    {
        while (true)
        {
            if (!isPlayerTurn)
            {
                foreach (GameObject enemy in enemies)
                {
                    StartCoroutine(TakeTurn(enemy));
                }
                yield return WaitUntilAllEnemiesHaveFinished();
                isPlayerTurn = true;
            }
            else
            {
                foreach (GameObject player in players)
                {
                     StartCoroutine(TakeTurn(player));
                }
                yield return WaitUntilAllPlayersHaveFinished();
                isPlayerTurn = false;
            }
        }
    }

    IEnumerator TakeTurn(GameObject combatant)
    {
        
        if (combatant == null)
        {
            Debug.LogError("Combatant is null");
            yield break;
        }

        Debug.Log(combatant.name + "'s turn");
        combatant.GetComponent<TurnTaker>().StartTurn();

         if (combatant.tag =="ColliderEnemyOne")
        {
            ProjectileEnemy projectileEnemy = combatant.GetComponentInChildren<ProjectileEnemy>();

            if (projectileEnemy != null)
            {
                
                Vector3 initialDirection = combatant.transform.forward;
                 projectileEnemy.CreateNewObject(initialDirection);

                 isPlayerTurn = true; //trigger players turn immediately
                 foreach (GameObject player in players)
                 {
                    StartCoroutine(TakeTurn(player));
                 }
                 yield return WaitUntilAllPlayersHaveFinished();

                 //Continue with projectile movement 
                 yield return SlowDownProjectile(projectileEnemy.instantiatedObject);
                 yield return new WaitForSeconds(2f); //adding delay to enemy's turn
                
                 //yield return new WaitForSeconds(1f);
                 //SlowDownProjectile(projectileEnemy.prefab)
                 //yield return new WaitForSeconds(2f);
            }
             else
             {
                 Debug.Log("Projectile enemy is null for " + combatant.name);
             }
                hitEnemy = GameObject.FindObjectOfType<ShootTowardsPlayer>();
             if (hitEnemy!= null && hitEnemy.hasHitEnemy == true)
             {
                if (territoryP != null)
                {
                    territoryP.transform.localScale += new Vector3(1, 0, 0); 
                    ProjectilePlayer projectilePlayer = GameObject.FindObjectOfType<ProjectilePlayer>();
                    if (projectilePlayer != null)
                    {
                        projectilePlayer.CreateNewObjectForPlayer(); 
                        Debug.Log("NEW OBJECT");
                    }
                    Destroy(gameObject); 
                }
               
                
             }
         

             
        }
       
        combatant.GetComponent<TurnTaker>().EndTurn();
    }

    IEnumerator SlowDownProjectile(GameObject projectile)
    {
        ShootTowardsPlayer shootTowardsPlayer = projectile.GetComponent<ShootTowardsPlayer>();
        if (shootTowardsPlayer == null)
    {
        Debug.LogError("ShootTowardsPlayer component not found on projectile: " + projectile.name);
        yield break;
    }
        float slowDownTime = 1.5f;
        float slowDownFactor = 0.01f;
        float stopTime = 4f;
        float stopDuration = 1f; //stoping projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on projectile: " + projectile.name);
            yield break;
        }

        Rigidbody localRb = rb;

        if (projectile == null || !projectile.activeSelf || rb == null)
         {
            Debug.LogError ("Projectile or Rigidbody has been destroyed or disabled");
            yield break;
         }

        if (rb != null)
        {
            // ShootTowardsPlayer shootTowardsPlayer = projectile.GetComponent<ShootTowardsPlayer>();
            // Vector3 initialDirection = (projectile.transform.position - ShootTowardsPlayer.target.position).normalized;

            Vector3 initialDirection = (projectile.transform.position - shootTowardsPlayer.target.position).normalized;
            float initialSpeed = 0.001f;
           
            float slowDownSpeed = Mathf.Max(initialSpeed * slowDownFactor, 0.01f); 

            
            Debug.Log("Initial speed: " + initialSpeed);
            Debug.Log("Initial direction: " + initialDirection);

            float timer = 0f;
            if (localRb!= null)
            {
                    while (timer < stopTime)
                {
                    if (shootTowardsPlayer.hasHitPlayer)
                    {
                        break;
                    }

                    if (rb!= null && rb.gameObject.activeSelf)
                    {
                        rb.velocity = Vector3.Lerp(rb.velocity, initialDirection * slowDownSpeed, timer / slowDownTime);
                    }
                    else
                    {
                        Debug.LogError("Rigidbody has been destroyed or disabled");
                        break;
                    }
                    // else if (timer < stopTime)
                    // {
                    //     rb.velocity = Vector3.Lerp(rb.velocity, initialDirection * 0.001f, (timer - slowDownTime) / (stopTime - slowDownTime));
                    // }
                    // else
                    // {
                    //     rb.velocity = initialDirection * 5f;
                    // }
                
                    timer += Time.deltaTime;
                    yield return null;
                }

            }
           

            //stop projectile for a little while
            if (rb!= null && rb.gameObject.activeSelf)
            {
                 rb.velocity = Vector3.zero;
                 yield return new WaitForSeconds(stopDuration);

            }
           
            
            //continue slowing down the projectile
            if (rb != null && rb.gameObject.activeSelf)
            {
                 rb.velocity = initialDirection * 5f;

                yield return new WaitForSeconds(0.1f);
                Debug.Log("Wait over");
            }
             

            //rb.AddForce(initialDirection * 10f, ForceMode.Impulse);

        }

        isPlayerTurn = true; // switch to player's turn
        yield break;

      
    }




    IEnumerator WaitUntilAllPlayersHaveFinished()
    {
        bool allPlayersFinished = false;
        while (!allPlayersFinished)
        {
            allPlayersFinished = true;
            foreach (GameObject player in players)
            {
                if (player.GetComponent<TurnTaker>().IsTakingTurn)
                {
                    allPlayersFinished = false;
                    break;
                }
            }

            yield return null;
        }
    }

    IEnumerator WaitUntilAllEnemiesHaveFinished()
    {
        bool allEnemiesFinished = false;
        while (!allEnemiesFinished)
        {
            allEnemiesFinished = true;
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<TurnTaker>().IsTakingTurn)
                {
                    allEnemiesFinished = false;
                    break;

                }
            }

            yield return null;
        }
    }



 
}
