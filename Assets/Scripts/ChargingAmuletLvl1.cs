using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingAmuletLvl1 : MonoBehaviour
{
   public float cooldownTime = 5f;
   public bool isOnCooldown = false;
    void Start()
    {
       
    }

    public IEnumerator ChargingCooldown(float cooldownTime)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
    

    
}
