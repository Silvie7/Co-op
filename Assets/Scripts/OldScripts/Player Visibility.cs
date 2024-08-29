using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    public Transform a, b;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("ColliderPlayerOne");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(a.position, b.position, out hit))
        {
            Debug.Log("found playerone");
        }
    }
}
