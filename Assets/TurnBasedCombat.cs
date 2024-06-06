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
        Debug.Log(combatant.name + "'s turn");
        combatant.GetComponent<TurnTaker>().StartTurn();
        ProjectileEnemy projectileEnemy = combatant.GetComponentInChildren<ProjectileEnemy>();

         if (combatant.tag =="Enemy")
         {
            if (projectileEnemy != null)
            {
                
                 projectileEnemy.CreateNewObject();

            }
             else
        {
            Debug.Log("Projectile enemy is null for " + combatant.name);
        }
           
            

         }
        yield return new WaitForSeconds(2f);
        combatant.GetComponent<TurnTaker>().EndTurn();
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
