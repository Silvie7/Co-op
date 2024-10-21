using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    public Transform playerTransfrom;
    public float dsitance = 5f;
    // Start is called before the first frame update
    
    private void LateUpdate()
    {
        playerTransfrom.position = playerTransfrom.position + playerTransfrom.forward * dsitance;

        float playerRotation = playerTransfrom.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, playerRotation);
    }
}
