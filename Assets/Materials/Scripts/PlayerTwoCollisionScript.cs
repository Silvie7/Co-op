using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCollisionScript : MonoBehaviour
{
    public float buttonCounterP2 = 0.0f;
    public bool holdButtonP2 = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            buttonCounterP2 += Time.deltaTime;

            if (buttonCounterP2 >= 1f)
            {
                holdButtonP2 = true;
                Debug.Log("Button r True");
                buttonCounterP2 = 0f;
            }
        }
        if (Input.GetKeyUp("r"))
        {
            holdButtonP2 = false;
            Debug.Log("Button r False");
            buttonCounterP2 = 0f;
        }

    }
}
