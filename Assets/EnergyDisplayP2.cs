using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyDisplayP2 : MonoBehaviour
{
    public Text energyText;
    public PlayerTwoManager playerTwoManager;
    // Start is called before the first frame update
    void Start()
    {
        //initialize the energy text 
        energyText.text = "Energy: " + playerTwoManager.p2Energy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //update the energy text
        energyText.text = "Energy: " + playerTwoManager.p2Energy.ToString(); 
    }
}
