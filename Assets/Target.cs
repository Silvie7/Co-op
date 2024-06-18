using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool player1Hit = false;
    public bool player2Hit = false;
    public bool bothHit = false;

    
    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player2Hit == true)
        {
            GetComponent<OutlineEffect>().EnableOutline();
        }
        else
        {
            GetComponent<OutlineEffect>().DisableOutline();
        }
       
    }

}
