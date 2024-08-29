using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool player1Hit = false;
    public bool player2Hit = false;
    public bool bothHit = false;
    public bool hasChosenTarget = false;
    private bool p2Key = false;
    
    private OutlineEffect outlineEffect;
    private AmuletRaycast_P2 amuletRaycast_P2;
    
    // Start is called before the first frame update
    void Start()
    {
        amuletRaycast_P2 = GameObject.FindObjectOfType<AmuletRaycast_P2>();
        outlineEffect = GetComponent<OutlineEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        p2Key = amuletRaycast_P2.p2Key;
        if (amuletRaycast_P2.chosenTarget == gameObject)
        {
            hasChosenTarget = true;
        }
        else
        {
            hasChosenTarget = false;

        }

        if (player2Hit || hasChosenTarget)
        {
            GetComponent<OutlineEffect>().EnableOutline();

        }
        else if (!player2Hit || !hasChosenTarget)
        {
            GetComponent<OutlineEffect>().DisableOutline();
        }
        
    }   
      

}
