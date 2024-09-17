using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayersActions playersActions;
    public Shield shield;
    public GameObject playerShield;

    public GameObject enemy1;
    public GameObject enemy2;
    public Transform position1; //position where enemy 1 moves to protect the sphere
    public Transform position2; //position where enemy 2 moves to protect the sphere
    public Transform startPosition1; //position where the enemy 1 returns
    public Transform startPosition2; //positon where the enemy 2 returns
    public Transform position3; // position where enemy 1 moves to protect the cube
    public Transform position4; //position where enemy 2 moves to protect the cube
    public GameObject enemyShield; //big shield for enemies
    public EnemyShield enemyShieldScript; //shield enemy script
    public AmuletRaycast_P1 rayCastP1;
    public AmuletRaycast_P2 rayCastP2;

    public GameObject shieldForE1; //small shield for enemy 1
    public GameObject shieldForE2; //small shield for enemy 2

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
        if (playersActions?.sameTargetChosen == true && shield.shieldHit == true)
        {
            switch (playersActions.finalTarget.name)        
            {
                case "Sphere":
                    if (shield?.shieldHit == true && !hasPrintedLog)
                    {
                        Debug.Log ("SHIELD HIT");
                        PerformRandomActionSphere();
                        hasPrintedLog = true; 
                        playersActions.sameTargetChosen = false;
                    }
                    else if (shield?.shieldHit == false)
                    {
                        hasPrintedLog = false;
                    }
                    break;
                case "Cube":
                    {
                        PerformActionCube();
                        hasPrintedLog = true;
                        playersActions.sameTargetChosen = false;
                    }
                    break;

                case "Enemy1":
                    if (shield?.shieldHit == true && !hasPrintedLog)
                    {
                        Debug.Log ("SHIELD HIT");
                        PerformRandomActionEnemy1();
                        hasPrintedLog = true; 
                        playersActions.sameTargetChosen = false;
                    }
                    else if (shield?.shieldHit == false)
                    {
                        hasPrintedLog = false;
                    }
                    break;
                case "Enemy2":
                    if (shield?.shieldHit == true)
                    {
                        PerformRandomActionEnemy2();
                        hasPrintedLog = true;
                        playersActions.sameTargetChosen = false;
                    }
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
            ActivateShieldSphere,
            // Action1,
            // Action2
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();     
         playersActions.finalTarget = null;           
    }

    void PerformRandomActionEnemy1()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShieldForEnemy1,
            BothActivateShield
            // Action4
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();    
         playersActions.finalTarget = null;
    }

    void PerformActionCube()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShieldForCube
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();
         playersActions.finalTarget = null;
    }
    
    void PerformRandomActionEnemy2()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShieldForEnemy2,
            BothActivateShield
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();
         playersActions.finalTarget = null;
    }
    
    void ActivateShieldSphere() //activates the big shield when aiming at sphere
    {
        StartCoroutine(MoveEnemy(enemy1, position1.position));
        StartCoroutine(MoveEnemy(enemy2, position2.position));
         playerShield.SetActive(false);
         shield.shieldHit = false;

        if (enemyShieldScript.eShieldHit == true)
        {
            enemyShield.SetActive(false);
             StartCoroutine(ResetPosition(enemy1, startPosition1.position));
             StartCoroutine(ResetPosition(enemy2, startPosition2.position));
        }   
        
    }

    void ActivateShieldForCube()
    {
        StartCoroutine(MoveEnemyCube(enemy2, position4.position)); 
        StartCoroutine(MoveEnemyCube(enemy1, position3.position));
        playerShield.SetActive(false);

        if (enemyShieldScript.eShieldHit == true)
        {
            StartCoroutine(ResetPositionCube(enemy2, startPosition1.position));
            StartCoroutine(ResetPositionCube(enemy1, startPosition2.position));
            enemyShield.SetActive(false);
             shield.shieldHit = false;
        }
    }

    IEnumerator MoveEnemy(GameObject enemy, Vector3 targetPosition) //moving enemy when aiming at sphere to the position of the sphere
    {
        float speed = 1f; //movement speed of the enemies
        while (Vector3.Distance(enemy.transform.position, targetPosition) > 0.01f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        enemy.transform.position = targetPosition;
        enemyShield.SetActive(true);
    }   
    
    IEnumerator ResetPosition(GameObject enemy, Vector3 startingPosition) //moving enemy back to starting position 
    {
        float speed = 1f;
        enemyShieldScript.eShieldHit = false;
        while (Vector3.Distance(enemy.transform.position, startingPosition)> 0.01f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startingPosition, speed * Time.deltaTime);
            yield return null;
        }
        enemy.transform.position = startingPosition;
    }

    IEnumerator MoveEnemyCube(GameObject enemy, Vector3 targetPosition)
    {
        float speed = 1f;
        while (Vector3.Distance(enemy.transform.position, targetPosition) > 0.01f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        enemy.transform.position = targetPosition;
        enemyShield.SetActive(true);
    }

    IEnumerator ResetPositionCube(GameObject enemy, Vector3 startingPosition)
    {
        float speed = 1f;
        while (Vector3.Distance(enemy.transform.position, startingPosition) > 0.01f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startingPosition, speed * Time.deltaTime);
            yield return null;
        }
        enemy.transform.position = startingPosition;
        enemyShieldScript.eShieldHit = false;
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
        shieldForE1.SetActive(true); //sets active the small shield for enemy one
        shield.shieldHit = false;
        if (enemyShieldScript.eShieldHit == true)
        {
            StartCoroutine(DeactivateShieldForE1());
        }
    }

    IEnumerator DeactivateShieldForE1()
    {
        yield return new WaitForSeconds(3f); //wait for 3 seconds
        shieldForE1.SetActive(false);
    }

    void BothActivateShield()
    {
        enemyShield.SetActive(true);
        shield.shieldHit = false;
        if (enemyShieldScript.eShieldHit == true)
        {
            StartCoroutine(DeactivateShieldForBoth());
        }
    }

    IEnumerator DeactivateShieldForBoth()
    {
        yield return new WaitForSeconds(3f); //wait for 3 seconds
        enemyShield.SetActive(false); //deactivate big enemy shield 
        shield.shieldHit = false;
    }

    void ActivateShieldForEnemy2()
    {
        shieldForE2.SetActive(true); //sets active the small shield for enemy two
        if (enemyShieldScript.eShieldHit == true)
        {
            StartCoroutine(DeactivateShieldForE2());
        }
    }

    IEnumerator DeactivateShieldForE2()
    {
        yield return new WaitForSeconds(3f);
        shieldForE2.SetActive(false); //deactivate small shield for enemy two
    }
}
