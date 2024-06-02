using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletScriptTest : MonoBehaviour
{
    public P1_Controller_Movement movementScript;
    private float rotationsNumber = 0;

    public bool rotatingLeft = false;
    public bool rotatingRight = false;
    public bool rotatingNo = false;
    
    float currentRotation;
    float timerRotationR;

    public enum RotationDirection 
    {
        NoRotation,
        Leftward,
        Rightward
    }
    Vector3 oldForward;
    RotationDirection rotationDirection;
    Vector3 forward;


    
   

    // Start is called before the first frame update
    void Start()
    {
        oldForward = transform.forward;
         
    }

    // Update is called once per frame
    void Update()
    {
        

        float horizontalInput = Input.GetAxis("P1C_Horizontal");
        float verticalInput = Input.GetAxis("P1C_Vertical");

        Vector3 moveVector = (Vector3.up * horizontalInput + Vector3.left * verticalInput);
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            
        }
        
        Vector3 cross = Vector3.Cross(oldForward, forward);

     if (cross.z > 0f) 
     {
         rotationDirection = RotationDirection.Rightward;
         rotatingLeft = true;
         rotatingRight = false;
         rotatingNo = false;
     }
     else if (cross.z < 0f) 
     {
        rotationDirection = RotationDirection.Leftward;
        rotatingRight = true;
        rotatingLeft = false;
        rotatingNo = false;
     }
        else 
    {
        rotationDirection = RotationDirection.NoRotation;
        rotatingRight = false;
        rotatingLeft = false;
        rotatingNo = true;

    }

        oldForward = transform.forward;
   
    }





}

