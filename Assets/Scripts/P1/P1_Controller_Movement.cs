using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Controller_Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private bool movement = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
         
        if(movement == true) 
        {
            float horizontalInput = Input.GetAxis("P1C_Horizontal");
            float verticalInput = Input.GetAxis("P1C_Vertical");
        
         Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
         movementDirection.Normalize();

            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        }

        // //Debug.Log(Input.GetButton("R2"));
        // if(Input.GetButton("R2"))
        // {
        //     Debug.Log ("movementFalse");
        //     movement = false;
        // }

    }



}
