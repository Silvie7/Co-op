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
    public GameObject enemyShield;

    public GameObject shieldE1;

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
                        PerformRandomActionSphere();
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
                    if (shield?.shieldHit == true && !hasPrintedLog)
                    {
                        Debug.Log ("SHIELD HIT");
                        PerformRandomActionEnemy1();
                        hasPrintedLog = true; 
                    }
                    else if (shield?.shieldHit == false)
                    {
                        hasPrintedLog = false;
                    }
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

    void PerformRandomActionSphere()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShield,
            Action1,
            Action2
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();                
    }

    void PerformRandomActionEnemy1()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShieldForEnemy1,
            Action3,
            Action4
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();    
    }
    
    
    void ActivateShield()
    {
        StartCoroutine(MoveEnemy(enemy1, position1.position));
        StartCoroutine(MoveEnemy(enemy2, position2.position));
    }

    IEnumerator MoveEnemy(GameObject enemy, Vector3 targetPosition)
    {
        float speed = 5.0f; //movement speed of the enemies
        while (Vector3.Distance(enemy.transform.position, targetPosition) > 0.01f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        enemy.transform.position = targetPosition;
        enemyShield.SetActive(true); 
    }   

    void Action1()
    {
        Debug.Log("ACTION1");
    }
    
    void Action2()
    {
        Debug.Log("ACTION2");
    }

     void Action3()
    {
        Debug.Log("ACTION3");
    }

     void Action4()
    {
        Debug.Log("ACTION4");
    }

    void ActivateShieldForEnemy1()
    {
        // shieldE1.SetActive(true);
  
    }
}
