using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P2 : MonoBehaviour
{
    public GameObject playerOne;
    //public AmuletControlls amuletScript;
    public bool P1Hit = false;
    int playerLayer;

    public GameObject target1; 
    public GameObject target2; 
    public GameObject target3; 
    public GameObject target4; 

    public bool target1Hit = false;
    public bool target2Hit = false;
    public bool target3Hit = false;
    public bool target4Hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f))
        {
           // Debug.Log("Hit something");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red );
           
           if (hitinfo.collider != null)
           {
            if (hitinfo.collider.tag == "ColliderPlayerOne")
            {
                Debug.Log("PLAYER ONE HIT");
                P1Hit = true;
            }
           }
            
            if (hitinfo.collider.gameObject == target1)
            {
                target1Hit = true;
                if (target1 != null && target1.GetComponent<OutlineEffect>() != null)
                {
                    target1.GetComponent<OutlineEffect>().EnableOutline();
                }
                
            }
            else if (hitinfo.collider.gameObject == target2)
            {
                target2Hit = true;
                if (target2 != null && target2.GetComponent<OutlineEffect>() != null)
                {
                    target2.GetComponent<OutlineEffect>().EnableOutline();
                }
                
            }
            else if (hitinfo.collider.gameObject == target3)
            {
                target3Hit = true;
                 if (target3 != null && target3.GetComponent<OutlineEffect>() != null)
                {
                    target3.GetComponent<OutlineEffect>().EnableOutline();
                }
                
            }
            else if (hitinfo.collider.gameObject == target4)
            {
                target4Hit = true;
                 if (target4 != null && target4.GetComponent<OutlineEffect>() != null)
                {
                    target4.GetComponent<OutlineEffect>().EnableOutline();
                }
                
            }
           
           
        }
        else
        {
            //Debug.Log("HIt nothing");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 20f, Color.green );
            P1Hit = false;

            if(target1!= null)
            {
                OutlineEffect outlineEffect = target1.GetComponent<OutlineEffect>();
                 if (outlineEffect!= null)
                {
                    target1.GetComponent<OutlineEffect>().DisableOutline();

                }

            }
                 
            if(target2!= null)
            {
                OutlineEffect outlineEffect = target2.GetComponent<OutlineEffect>();

                if (outlineEffect!= null)
                {
                    target2.GetComponent<OutlineEffect>().DisableOutline();

                }
                
            }
            
            if(target3!= null)
            {
                OutlineEffect outlineEffect = target3.GetComponent<OutlineEffect>();
                if (outlineEffect!= null)
                {
                    target3.GetComponent<OutlineEffect>().DisableOutline();
                }
                
            }
            
            if(target4!= null)
            {
                OutlineEffect outlineEffect = target4.GetComponent<OutlineEffect>();
                if (outlineEffect!= null)
                {
                    target4.GetComponent<OutlineEffect>().DisableOutline();
                }
               
            }
            
        }
    }
}
