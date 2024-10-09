using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingObject: MonoBehaviour
{
   public PlayerManager playerManager;
   public float cooldownTime = 5f;
   public bool isOnCooldown = false;


    public IEnumerator ChargingCooldown(float cooldownTime)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
    
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("P1TriggerCollider"))
        {
            playerManager.p1ChargeDistanceIs = true;
        }

        if (collider.gameObject.CompareTag("P2TriggerCollider"))
        {
            playerManager.p2ChargeDistanceIs = true;
            Debug.Log("IsIn");
        }
    }
    

    
}
