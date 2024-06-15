using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletRaycast_P1 : MonoBehaviour
{
    public GameObject playerTwo;
    //public AmuletControlls amuletScript;
    public bool P2Hit = false;
   

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    public bool target1Hit = false;
    public bool target2Hit = false;
    public bool target3Hit = false;
    public bool target4Hit = false;

    public bool targetChosen = false;
    public GameObject chosenTarget;

    int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target1Hit = false;
        target2Hit = false;
        target3Hit = false;
        target4Hit = false;


       if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f))
        {
           // Debug.Log("Hit something");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red );
           
           if (hitinfo.collider != null)
           {
            if (hitinfo.collider.tag == "ColliderPlayerTwo")
            {
                Debug.Log("PLAYER TWO HIT");
                P2Hit = true;
            }
           }
            
            if (hitinfo.collider.gameObject == target1)
            {
                target1Hit = true;
                if (target1 != null && target1.GetComponent<OutlineEffect>() != null)
                {
                    target1.GetComponent<OutlineEffect>().EnableOutline();
                    if (Input.GetButton("Circle"))
                    {
                        chosenTarget = target1;
                        targetChosen = true; 
                        Debug.Log("Target Choosen");
                    }
                }
            }
            else
            {
                target1Hit = false;
            }
            if (hitinfo.collider.gameObject == target2)
            {
                target2Hit = true;
                if (target2 != null && target2.GetComponent<OutlineEffect>() != null)
                {
                    target2.GetComponent<OutlineEffect>().EnableOutline();
                     if (Input.GetKey("o"))
                    {
                        chosenTarget = target2;
                        targetChosen = true; 
                    }
                }  
            }
            else
            {
                target2Hit = false;
            }            
            if (hitinfo.collider.gameObject == target3)
            {
                target3Hit = true;
                 if (target3 != null && target3.GetComponent<OutlineEffect>() != null)
                {
                    target3.GetComponent<OutlineEffect>().EnableOutline();
                     if (Input.GetKey("o"))
                    {
                        chosenTarget = target3;
                        targetChosen = true; 
                    }
                } 
            }
              else
            {
                target3Hit = false;
            }    
            if (hitinfo.collider.gameObject == target4)
            {
                target4Hit = true;
                 if (target4 != null && target4.GetComponent<OutlineEffect>() != null)
                {
                    target4.GetComponent<OutlineEffect>().EnableOutline();
                     if (Input.GetKey("o"))
                    {
                        chosenTarget = target4;
                        targetChosen = true; 
                    }
                } 
            }
             else
            {
                target4Hit = false;
            }    
           
           
        }
        else
        {
            //Debug.Log("HIt nothing");
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 20f, Color.green );
            P2Hit = false;
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
