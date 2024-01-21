using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionControlls : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public PlayerOneCollisionScript oneScript;
    public GameObject playerOne;
    private bool holdBothButtonsFusion = false;
  
    

    // Start is called before the first frame update
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


        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown("e") && Input.GetKeyDown("r"))
        {
            holdBothButtonsFusion = true;
        }
        
       if (holdBothButtonsFusion == true)
        {
            
            oneScript.playerTwo.SetActive(true);
            playerOne.SetActive(true);
            gameObject.SetActive(false);
           
        }
    }
}
