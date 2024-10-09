using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyDisplay : MonoBehaviour
{
    public Text energyText;
    public PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the energy text 
        energyText.text = "Energy: " + playerManager.player1Energy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //update the energy text
        energyText.text = "Energy: " + playerManager.player1Energy.ToString(); 
    }
}
