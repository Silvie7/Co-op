using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsManager : MonoBehaviour
{
    public enum Turn { Enemy, Player}

    public Turn currentTurn = Turn.Enemy;

    public bool playerHit = false;

    public ProjectileEnemy projectileEnemy;
    public ShootTowardsPlayer shootTowardsPlayer;
    public bool canSelectP1 = false; //checks if players can start selecting the targets
    public bool canSelectP2 = false;
    public ChargingObject chargingObject;
    private bool gameStart = false;
    public PlayerManager pActionScript;
    private PlayerOneManager p1Manager;
    private PlayerTwoManager p2Manager;
   
    
    
    private GameObject ball;
    public Transform ballPosition;


    // Start is called before the first frame update
    void Start()
    {
        //its enemies turn and they create the ball 
        gameStart = true;
        StartCoroutine(CheckForPlayerHit());
        p1Manager = FindObjectOfType<PlayerOneManager>();
        p2Manager = FindObjectOfType<PlayerTwoManager>();
      
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //If currentTurn is Turn.Enemy, the script calls the EnemyAction() method and then calls the SwitchTurn() method.
        if (currentTurn == Turn.Enemy)
        {
            if (gameStart == true)
            {
                //when the game starts the enemy creates new ball and shoots it.then switches turn
                Debug.Log ("Is enemies turn");
                Vector3 initialDirection = transform.forward;
                projectileEnemy.CreateNewObject(initialDirection);
                gameStart = false;
                StartCoroutine(SwitchTurnAfterDelay(2f));
            }
        }
        else
        {
            Debug.Log ("Is players turn");
        }

        //PLAYERS TURN
        //BOTH PLAYERS PRESS X AND SET ACTIVE SHIELD
        if (currentTurn == Turn.Player)
        {
            
           
        }
    }

    //Call this to have little delay and then switch turn
    IEnumerator SwitchTurnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SwitchTurn();
    }

    //checks if the player is hit by the ball all the time
    IEnumerator CheckForPlayerHit()
    {
        Debug.Log("CheckForPlayerHit coroutine started");
        while(true)
        {
            if (playerHit == true)
            {
                Debug.Log("HAS HIT PLAYER");
                //if the ball hits one of the players, the enemy creates new one and switches turn
                currentTurn = Turn.Enemy;
                Vector3 initialDirection = transform.forward;
                projectileEnemy.CreateNewObject(initialDirection);
                playerHit = false;
                SwitchTurn();
            }
            yield return null; 
            //wait for the next frame
        }
    }
    

    void SwitchTurn()
    {
        currentTurn = (currentTurn == Turn.Enemy) ? Turn.Player : Turn.Enemy;
    }

    // //ENEMY ACTIONS
    // void EnemyAction()
    // {
    //     //enemy does something
    // }

    // //PLAYER ACTIONS
    // void PlayerAction()
    // {
    //     //player does something
    // }
}


