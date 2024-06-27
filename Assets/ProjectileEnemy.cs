using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject prefab;
    public Transform player1;
    public Transform player2;

    public GameObject instantiatedObject;

    

    private Transform targetPlayer;

    

    
    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    // Update is called once per frame
    public void CreateNewObject(Vector3 initialDirection)
    {
       
       
      instantiatedObject = Instantiate(prefab, transform.position, Quaternion.LookRotation(initialDirection));

      targetPlayer = Random.value > 0.5? player1 : player2;

      instantiatedObject.GetComponent<ShootTowardsPlayer>().target = targetPlayer;
      instantiatedObject.GetComponent<ShootTowardsPlayer>().initialDirection = initialDirection;

      

             

        

      
      
          
       
        
    }

   
    
}
