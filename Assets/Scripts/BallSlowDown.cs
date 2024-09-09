using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSlowDown : MonoBehaviour
{
    public float slowDownFactor = 0.5f;
    public float slowDownForce = 10f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collider.gameObject. GetComponent<Rigidbody>();
           
            if (rb != null)
            {
                rb.AddForce(-rb.velocity * slowDownFactor, ForceMode.VelocityChange);
                Debug.Log("INSIDE");
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(-rb.velocity * slowDownFactor, ForceMode.VelocityChange);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(rb.velocity * slowDownFactor, ForceMode.VelocityChange);
            }
        }
    }
   
}
