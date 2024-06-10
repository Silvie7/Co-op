using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombat : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();

    private bool isPlayerTurn = false;

    // Start is called before the first frame update
    void Start()
    {
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
        ProjectileEnemy projectileEnemy = combatant.GetComponentInChildren<ProjectileEnemy>();

         if (combatant.tag =="Enemy")
         {
            if (projectileEnemy != null)
            {
                
                Vector3 initialDirection = combatant.transform.forward;
                 projectileEnemy.CreateNewObject(initialDirection);
                 yield return SlowDownProjectile(projectileEnemy.instantiatedObject);
                 //yield return new WaitForSeconds(1f);
                 //SlowDownProjectile(projectileEnemy.prefab)
                 //yield return new WaitForSeconds(2f);
            }
             else
        {
            Debug.Log("Projectile enemy is null for " + combatant.name);
        }   

         }
       
        combatant.GetComponent<TurnTaker>().EndTurn();
    }

    IEnumerator SlowDownProjectile(GameObject projectile)
    {
        float slowDownTime = 1f;
        float slowDownFactor = 0.1f;
         Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 initialDirection = Vector3.forward;
              float initialSpeed = 10f;
            float slowDownSpeed = Mathf.Max(initialSpeed * slowDownFactor, 0.1f); // Set a minimum speed of 0.1f

            
            Debug.Log("Initial speed: " + initialSpeed);
            Debug.Log("Initial direction: " + initialDirection);

            float timer = 0f;
             while (timer < slowDownTime)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, initialDirection * slowDownSpeed, timer / slowDownTime);
                timer += Time.deltaTime;
                 yield return null;
            }

              rb.velocity = initialDirection * 5f;

              yield return new WaitForSeconds(0.1f);
              Debug.Log("Wait over");

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
