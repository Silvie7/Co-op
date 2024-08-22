using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingAmuletLvl1 : MonoBehaviour
{
    public float cooldownTime = 5f;
    private bool isOnCooldown = false;

    public bool canCharge { get { return !isOnCooldown;} }

    // Start is called before the first frame update
    void Start()
    {
        isOnCooldown = false;
    }

    // Update is called once per frame
   public void StartCooldown()
    {
        isOnCooldown = true;
        StartCoroutine(ResetCooldown());
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
}
