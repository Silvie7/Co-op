using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public float enemy1Energy = 10;
    public float enemy2Energy = 10;

    public GameObject enemyChargingObject; //object that enemies charge thier energy from
    public GameObject chargingEnemy; //the enemy that is charging its energy
    public GameObject protectingEnemy; //the enemy that protects the field
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemyBigShield;
    public GameObject enemy1Shield;
    public GameObject enemy2Shield;
    public GameObject startingPosE1; //position where enemy one is starting at
    public GameObject startingPosE2; //position where enemy two is starting at

    public PlayerManager playerManager;
    public CursorManager cursorManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when the ball gets the info that it hit any shield - it will turn shieldHit == true
        //then the enemies will take the targetPositon info and will check where the players have been aiming at
        //based on their energy levels they will react randomly, same reaction as player maybe some unique ones based on who the boss is 
        //connected always, some fast...
        // they will slowly start going back to their starting spot but this can be inttreputed by player reaction 


            //get the final target position
            //call the reaction
            //always walk to the positon to react to it, same as player


            //choose random action - based on who has lower energy, that enemy goes to charge and the other enemy deflects the ball 
            //or choose action big shield for now 
            //while one charges, the other one can deflect aiming at one of players randomly
            //deactivate the charging object for a while to make the enemies withou the energy
        

    }

    public void RandomAction() //calling this in every player shield sccrip
    {
        int randomChoice = Random.Range(0, 2);
        if (randomChoice == 0)
        {
            BothShield();
        }
        else
        {
            oneChargesOtherProtects();

        }
    }
    void BothShield()
    {
        if (cursorManager.target != null)
        {
            StartCoroutine(MoveBothEnemies(enemy1, enemy2, cursorManager.target.transform.position));
        }

        //both enemies make the big shield and walk towards to where the target is aiming at and deflect it towards random positon in the field or they target the energy object

    }

    IEnumerator MoveBothEnemies(GameObject enemy1, GameObject enemy2, Vector3 cursorPosition)
    {
        float speed = 3f;
        Vector3 enemy1Position = new Vector3(enemy1.transform.position.x, enemy1.transform.position.y, cursorManager.target.transform.position.z);
        Vector3 enemy2Position = new Vector3(enemy2.transform.position.x, enemy2.transform.position.y, cursorManager.target.transform.position.z);

        //add offset to enemy  position so he is not too close to the enemy1
        enemy2Position += new Vector3(5f, 0f, 0f); //offset

        while (Vector3.Distance(enemy1.transform.position, enemy1Position) > 0.01f || Vector3.Distance(enemy2.transform.position, enemy2Position) > 0.01f)
        {
            enemy1.transform.position = Vector3.MoveTowards(enemy1.transform.position, enemy1Position, speed * Time.deltaTime);
            enemy2.transform.position = Vector3.MoveTowards(enemy2.transform.position, enemy2Position, speed * Time.deltaTime);
            enemyBigShield.SetActive(true);
            yield return null;
        }
    }

    void oneChargesOtherProtects()
    {
        if (enemy1Energy < enemy2Energy)
        {
            chargingEnemy = enemy1;
            protectingEnemy = enemy2;
        }
        else if (enemy2Energy < enemy1Energy)
        {
            chargingEnemy = enemy2;
            protectingEnemy = enemy1;
        }
        else
        {
            //if both enemies have the same energy, choose one randomly 
            int randomChoice = Random.Range(0, 2);
            if (randomChoice == 0)
            {
                chargingEnemy = enemy1;
                protectingEnemy = enemy2;
                enemy2.SetActive(true);
            }
            else
            {
                chargingEnemy = enemy2;
                protectingEnemy = enemy1;
                enemy1Shield.SetActive(true);
            }
        }

        //calculate the target position
        Vector3 chargingPosition = enemyChargingObject.transform.position;
        Vector3 protectingPosition = cursorManager.target.transform.position;

        //add offset to the position


        //Move the enemies to their target position
        StartCoroutine(MoveEnemy(chargingEnemy, chargingPosition));
        StartCoroutine(MoveEnemy(protectingEnemy, protectingPosition));
    }

    IEnumerator MoveEnemy(GameObject enemy, Vector3 cursorPosition)
    {
        float speed = 3f;
        Vector3 chargingPosition = new Vector3(chargingEnemy.transform.position.x, chargingEnemy.transform.position.y, enemyChargingObject.transform.position.z);
        Vector3 protectingPosition = new Vector3(protectingEnemy.transform.position.x, protectingEnemy.transform.position.y, cursorPosition.z);

        //add offset to enemy  position so he is not too close to the enemy1


        while (Vector3.Distance(chargingEnemy.transform.position, chargingPosition) > 0.01f || Vector3.Distance(protectingEnemy.transform.position, protectingPosition) > 0.01f)
        {
            chargingEnemy.transform.position = Vector3.MoveTowards(chargingEnemy.transform.position, chargingPosition, speed * Time.deltaTime);
            protectingEnemy.transform.position = Vector3.MoveTowards(protectingEnemy.transform.position, protectingPosition, speed * Time.deltaTime);
            yield return null;
        }

    }

    IEnumerator MoveEnemyBack()
    {
        float speed = 3f;
        Vector3 startingPositionE1 = new Vector3(enemy1.transform.position.x, enemy1.transform.position.y, startingPosE1.transform.position.z);
        Vector3 startingPositionE2 = new Vector3(enemy2.transform.position.x, enemy2.transform.position.y, startingPosE2.transform.position.z);
        while (Vector3.Distance(enemy1.transform.position, startingPositionE1) > 0.01f || Vector3.Distance(enemy2.transform.position, startingPositionE2) > 0.01f)
        {
            enemy1.transform.position = Vector3.MoveTowards(chargingEnemy.transform.position, startingPositionE1, speed * Time.deltaTime);
            enemy2.transform.position = Vector3.MoveTowards(protectingEnemy.transform.position, startingPositionE2, speed * Time.deltaTime);
            playerManager.shieldHit = false;
            yield return null;
        }
        if (enemyBigShield.activeSelf == true)
        {
            enemyBigShield.SetActive(false);
        }

        if (enemy1Shield.activeSelf == true)
        {
            enemy1Shield.SetActive(false);
        }

        if (enemy2Shield.activeSelf == true)
        {
            enemy2Shield.SetActive(false);
        }


    }
    //this only happens when the enemies have lower energy than 6
    //it will choose the enemy with lower number or randomly chooses one if they have the same one 
    //one nemy goes to charge and the other one tries to deflect the ball
    //for now no failing options

}
