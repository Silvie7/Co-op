using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletControlls : MonoBehaviour
{
  public P1_Controller_Movement movementScript;
    private float rotationsNumber = 0;

    public bool rotatingLeft = false;
    public bool rotatingRight = false;
    
    float currentRotation;
    float timerRotationR;
    float rotationDelta;
   

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Amulet_Horizontal");
        float verticalInput = Input.GetAxis("Amulet_Vertical");

        Vector3 moveVector = (Vector3.up * horizontalInput + Vector3.left * verticalInput);
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            
        }
        
        CompareRotation();
    }


void FixedUpdate()
{
    currentRotation = transform.rotation.eulerAngles.z;
   if (rotationDelta > 180f)  {
        currentRotation += 360f;
    }

     Debug.Log(currentRotation);
}

void CompareRotation()
{
    if (transform.rotation.eulerAngles.z > currentRotation)
    {
        rotatingLeft = true;
        rotatingRight = false;
    }
    if (transform.rotation.eulerAngles.z < currentRotation)
    {
        rotatingRight = true;
        rotatingLeft = false;
    }

   // timerRotationR += Time.deltaTime;
   // if(rotatingRight == true & timerRotationR > 0.5f)
   // {
       // Debug.Log("ROTATING");
       // timerRotationR = timerRotationR - 0.5f;
   // }

}
}
