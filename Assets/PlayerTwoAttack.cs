using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoAttack : MonoBehaviour
{
    public bool canAttack = false;
    public GameObject prefabPlayer2;
    public Transform enemy1;
    public Transform enemy2;
    private Transform targetEnemy1;
    // Start is called before the first frame update
    void Start()
    {
        CreateNewObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void CreateNewObject()
    {
        if (Input.GetButton("Triangle"))
        {
            GameObject newObject = Instantiate(prefabPlayer2, transform.position, transform.rotation);

            targetEnemy1 = Random.value > 0.5? enemy1 : enemy2;

            newObject.GetComponent<ShootTowardsEnemy>().target = targetEnemy1;
            Debug.Log("Player attacks enemy!");

        }
       
    }
}
