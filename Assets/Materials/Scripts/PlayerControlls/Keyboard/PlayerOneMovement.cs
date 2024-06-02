using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Light testLight;
    public float rotationSpeed;
    public GameObject fusion;
    // Start is called before the first frame update
    public GameObject playerOne;
    public GameObject playerTwo;
   
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("P1_Horizontal");
        float verticalInput = Input.GetAxis("P1_Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

     private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "ColliderPlayerTwo")
        {
           testLight.intensity = 5f;
        }
        if (collision.gameObject.tag == "ColliderPlayerTwo" && PlayerFusionController.holdButtonBoth == true)
        {
            if (playerTwo != null) 
            {
                fusion.SetActive(true);
                playerOne.SetActive(false);
                playerTwo.SetActive(false);
                PlayerFusionController.holdButtonBoth = false;
                
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
           testLight.intensity = 1f;
        
    }
    
}
