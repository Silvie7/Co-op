using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTaker : MonoBehaviour
{
    public bool IsTakingTurn { get; set; }
    // Start is called before the first frame update
   
   public void StartTurn()
   {
    IsTakingTurn = true;
   }

   public void EndTurn()
   {
    IsTakingTurn = false;
   }
}
