using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Controller_Movement : MonoBehaviour
{
     public float speed;
    public float rotationSpeed;

    public GameObject shieldP2;
    public Vector3 shieldOffset = new Vector3(0, 0, 0);

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("P2_Horizontal");
        float verticalInput = Input.GetAxis("P2_Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        UpdateShieldPosition();
    }
    void UpdateShieldPosition()
    {
        if (shieldP2 != null)
        {
            // Position the shield in front of the player based on the player's forward direction
            Vector3 shieldPosition = transform.position + transform.forward * shieldOffset.z + transform.up * shieldOffset.y + transform.right * shieldOffset.x;
            shieldP2.transform.position = shieldPosition;

            // Rotate the shield so its X-axis faces forward in the direction the player is facing
            Quaternion shieldRotation = Quaternion.LookRotation(transform.forward, Vector3.up);

            // Apply the calculated rotation to the shield, ensuring the X-axis stays forward
            shieldP2.transform.rotation = shieldRotation;
        }
    }
}
