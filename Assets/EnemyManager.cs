using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayersActions playersActions;
    public Shield shield;

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
                    if (shield?.shieldHit == true)
                    {
                        Debug.Log ("SHIELD HIT");
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
}
