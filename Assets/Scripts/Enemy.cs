using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject lighEnemyTwo;
       private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("passing", true);

     if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
     {
        Debug.Log("not playing");
     }
     else
     {
        lighEnemyTwo.SetActive(false);
        Debug.Log("playing");
     }
      
            
        
       
        
        

    }
}
