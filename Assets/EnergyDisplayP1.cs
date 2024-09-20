using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyDisplay : MonoBehaviour
{
    public Text energyText;
    public PlayerOneManager playerOneManager;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the energy text 
        energyText.text = "Energy: " + playerOneManager.p1Energy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //update the energy text
        energyText.text = "Energy: " + playerOneManager.p1Energy.ToString(); 
    }
}
