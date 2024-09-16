using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelectorP1 : MonoBehaviour
{
   public GameObject[] objects;

    //the material to aply when object is selected by p2
    public Material selectedMaterialP1;

    public GameObject chosenObjectP1;
    public bool hasBeenChosenP1 = false;

    //the currect selected object index
    private int selectedIndex = 0;
    private Material[] originalMaterials;

    private int previousSelectedIndex = -1; //index of the previously seected object

    private TurnsManager turnsManager;

    // Start is called before the first frame update
    void Start()
    {
        turnsManager = GameObject.FindObjectOfType<TurnsManager>();
        originalMaterials = new Material[objects.Length];

        //store the original materials of the objects
        for (int i = 0; i < objects.Length; i++)
        {
            originalMaterials[i] = objects[i].GetComponent<Renderer>().sharedMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // float dPadHorizontal = Input.GetAxis("DPadHorizontal");
        //  Debug.Log("DPadHorizontal: " + dPadHorizontal);
        // If canSelect is true, check if the LeftArrow or RightArrow key was pressed
        if(turnsManager.canSelectP1 == true && !hasBeenChosenP1)
        {
             // If LeftArrow was pressed, select the previous object
            if (Input.GetButton("Left"))
            {
                selectedIndex = (selectedIndex - 1 + objects.Length) % objects.Length;
                ChangeSelectedObjectMaterial(selectedIndex);
            }
            
             // If LeftArrow was pressed, select the previous object
             else if (Input.GetButton("Right"))
             {
                selectedIndex = (selectedIndex + 1) % objects.Length;
                ChangeSelectedObjectMaterial(selectedIndex);
             }

             else if (Input.GetButton("Circle") && previousSelectedIndex != -1)
             {
                chosenObjectP1 = objects[previousSelectedIndex];
                hasBeenChosenP1 = true;
             }

        }
    }

    void ChangeSelectedObjectMaterial(int index)
    {
        if (previousSelectedIndex != -1 && objects[previousSelectedIndex] != chosenObjectP1)
        {
            objects[previousSelectedIndex].GetComponent<Renderer>().material = originalMaterials[previousSelectedIndex];
        }

        //Apply the selected material to the newly selected object
        if (objects[index] != null)
        {
           objects[index].GetComponent<Renderer>().material = selectedMaterialP1;
        }

        //Update the previouslSelectedIndex to the current index
        previousSelectedIndex = index;
    }
}

