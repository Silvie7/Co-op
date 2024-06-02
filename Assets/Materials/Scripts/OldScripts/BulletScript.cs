using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    public GameObject targetEnemy;
    
    // Start is called before the first frame update
    void Awake ()
    {
        Destroy(targetEnemy, life);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(targetEnemy);
    }
}
