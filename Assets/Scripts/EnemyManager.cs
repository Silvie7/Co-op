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
    public bool nullTheTarget = false;
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

    public ShieldForE1 e1Shield;
    public ShieldForE2 e2Shield;
    private bool hasPrintedLog = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playersActions = FindObjectOfType<PlayersActions>();
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

         if (enemyShield.active == true && enemyShieldScript.eShieldHit == true)
        {
            if (playersActions.finalTarget != null)
            {
                if (playersActions.finalTarget.name == "Cube")
                {
                    StartCoroutine(ResetPositionCube(enemy2, startPosition1.position));
                    StartCoroutine(ResetPositionCube(enemy1, startPosition2.position));
                    enemyShield.SetActive(false);
                    shield.shieldHit = false;
                    enemyShieldScript.eShieldHit = false;
                    nullTheTarget = true;   
                }
                if (playersActions.finalTarget.name == "Sphere")
                {
                    enemyShield.SetActive(false);
                    StartCoroutine(ResetPosition(enemy1, startPosition1.position));
                    StartCoroutine(ResetPosition(enemy2, startPosition2.position));
                    shield.shieldHit = false;
                    enemyShieldScript.eShieldHit = false;
                    nullTheTarget = true;   
                } 
                if (playersActions.finalTarget.name == "Enemy2" || playersActions.finalTarget.name == "Enemy1" )
                {
                    {
                        shield.shieldHit = false;
                        enemyShieldScript.eShieldHit = false;
                        nullTheTarget = true;
                        StartCoroutine(DeactivateShieldForBoth());
                    }
                }   
            }
        }

        if (e1Shield != null)
        {
             if (shieldForE1.activeSelf && e1Shield.e1ShieldHit == true)
            {
                if (playersActions.finalTarget.name == "Enemy1")
                {
                    StartCoroutine(DeactivateShieldForE1());
                }
            }
        }
       
       if (e2Shield != null)
       {
            if (shieldForE2.activeSelf && e2Shield.e2ShieldHit == true)
            {
                if (playersActions.finalTarget.name == "Enemy2")
                {
                    StartCoroutine(DeactivateShieldForE2());
                }
            
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
               
    }

    void PerformRandomActionEnemy1()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShieldForEnemy1
            // BothActivateShield
            // Action4
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();    
        
        
    }

    void PerformActionCube()
    {
        System.Action[] randomActions = new System.Action[]
        {
            ActivateShieldForCube
        };
        int randomIndex = Random.Range(0, randomActions.Length);
        randomActions[randomIndex]();
        
         
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
         
    }
    
    void ActivateShieldSphere() //activates the big shield when aiming at sphere
    {
        StartCoroutine(MoveEnemy(enemy1, position1.position));
        StartCoroutine(MoveEnemy(enemy2, position2.position));
         playerShield.SetActive(false);
         shield.shieldHit = false;

        
    }

   public void ActivateShieldForCube()
    {
        StartCoroutine(MoveEnemyCube(enemy2, position4.position)); 
        StartCoroutine(MoveEnemyCube(enemy1, position3.position));
        playerShield.SetActive(false);
        shield.shieldHit = false;
        
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
        playerShield.SetActive(false);
        shield.shieldHit = false;
        shieldForE1.SetActive(true); //sets active the small shield for enemy one
        
    }

    IEnumerator DeactivateShieldForE1()
    {
        yield return new WaitForSeconds(2f); //wait for 3 seconds
        shieldForE1.SetActive(false);
        nullTheTarget = true;
        e1Shield.e1ShieldHit = false;
       
    }

    void BothActivateShield()
    {
        enemyShield.SetActive(true);
        if (enemyShieldScript.eShieldHit == true)
        {
            StartCoroutine(DeactivateShieldForBoth());
        }
        playerShield.SetActive(false);
    }

    IEnumerator DeactivateShieldForBoth()
    {
        yield return new WaitForSeconds(2f); //wait for 3 seconds
        enemyShield.SetActive(false); //deactivate big enemy shield 
        shield.shieldHit = false;
    }

    void ActivateShieldForEnemy2()
    {
        playerShield.SetActive(false);
        shield.shieldHit = false;
        shieldForE2.SetActive(true); //sets active the small shield for enemy two
    }

    IEnumerator DeactivateShieldForE2()
    {
        e2Shield.e2ShieldHit = false;
        nullTheTarget = true;
        yield return new WaitForSeconds(2f);
        shieldForE2.SetActive(false); //deactivate small shield for enemy two
        shield.shieldHit = false;
    }
}
