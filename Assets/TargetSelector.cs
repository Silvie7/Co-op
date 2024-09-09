using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    //objects that can be selected
    public GameObject[] objects;

    //the material to aply when object is selected by p2
    public Material selectedMaterialP2;

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
        // If canSelect is true, check if the LeftArrow or RightArrow key was pressed
        if(turnsManager.canSelect == true)
        {
             // If LeftArrow was pressed, select the previous object
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selectedIndex = (selectedIndex - 1 + objects.Length) % objects.Length;
                ChangeSelectedObjectMaterial(selectedIndex);
            }
        }
        // If RightArrow was pressed, select the next object
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex = (selectedIndex + 1) % objects.Length;
            ChangeSelectedObjectMaterial(selectedIndex);
        }
    }

    void ChangeSelectedObjectMaterial(int index)
    {
        if (previousSelectedIndex != -1)
        {
            objects[previousSelectedIndex].GetComponent<Renderer>().material = originalMaterials[previousSelectedIndex];
        }

        //Apply the selected material to the newly selected object
        if (objects[index] != null)
        {
           objects[index].GetComponent<Renderer>().material = selectedMaterialP2;
        }

        //Update the previouslSelectedIndex to the current index
        previousSelectedIndex = index;
    }
}
