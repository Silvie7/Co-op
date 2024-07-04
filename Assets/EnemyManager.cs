using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayersActions playersActions;
    public Shield shield;

    public GameObject enemy1;
    public GameObject enemy2;
    public Transform position1;
    public Transform position2;

    private bool hasPrintedLog = false;
    // Start is called before the first frame update
    void Start()
    {
        playersActions = playersActions ?? FindObjectOfType<PlayersActions>();
        shield = shield ?? FindObjectOfType<Shield>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playersActions?.sameTarget == true && playersActions.p2Raycast != null && playersActions.p2Raycast.chosenTarget != null)
        {
            switch (playersActions.p2Raycast.chosenTarget.name)        
            {
                case "Sphere":
                    if (shield?.shieldHit == true && !hasPrintedLog)
                    {
                        Debug.Log ("SHIELD HIT");
                        ActivateShield();
                        hasPrintedLog = true;
                      
                    }
                    else if (shield?.shieldHit == false)
                    {
                        hasPrintedLog = false;
                    }
                    break;
                case "Cube":
                    break;
                case "Enemy1":
                    break;
                case "Enemy2":
                    break;

                default:
                    break;
            }
        }
       
    }

    public void ResetPrintedLog()
    {
        hasPrintedLog = false;
    }

      void PrintRandomLog()
        {
            string[] randomLogs = new string[]
            {
                "RANDOM 1",
                "RANDOM 2",
                "RANDOM 3"   
            };
            int randomIndex = Random.Range(0, randomLogs.Length);
            string randomLog = randomLogs[randomIndex];
            Debug.Log(randomLog);
                    
                       
        }
    
    
    void ActivateShield()
    {
        StartCoroutine(MoveEnemy(enemy1, position1.position));
        StartCoroutine(MoveEnemy(enemy2, position2.position));
    }

    IEnumerator MoveEnemy(GameObject enemy, Vector3 targetPosition)
    {
        float speed = 2.0f; //movement speed of the enemies
        while (Vector3.Distance(enemy.transform.position, targetPosition) > 0.01f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        enemy.transform.position = targetPosition;
    }   
}
