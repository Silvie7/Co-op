using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingObject: MonoBehaviour
{
   public float cooldownTime = 5f;
   public bool isOnCooldown = false;

    public PlayerManager playerManager;

    public IEnumerator ChargingCooldown(float cooldownTime)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
    
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerOne"))
        {
            playerManager.p1ChargeDistanceIs = true;
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerTwo"))
        {
            playerManager.p2ChargeDistanceIs = true;
        }
    }
    

    
}
