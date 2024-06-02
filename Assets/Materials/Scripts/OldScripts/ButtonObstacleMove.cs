using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObstacleMove : MonoBehaviour
{
    private GameObject colliderPlayerTwo;
    public GameObject playerTwo;
    public GameObject obstacle;
    public float speed;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "ColliderPlayerTwo" && Input.GetKey("p"))
        {
           
           obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, target.transform.position, speed);
    
           
        }
    }
}
