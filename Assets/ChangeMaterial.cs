using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterialP2;
    public Material newMaterialP1;
    public Material passiveMaterial;
    public bool changeMatP2;
    public bool changeMatP1;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeMatP1)
        {
            ChangeObjectMaterialP1();
            changeMatP1 = false;
        }
        else
        {
            ChangeMaterialBack();
        }
        
        if (changeMatP2)
        {
            ChangeObjectMaterialP2();
            changeMatP2 = false;
            
        }
        else
        {
            ChangeMaterialBack();
        }
    }
    

    void ChangeObjectMaterialP1()
    {
        renderer.material = newMaterialP1;
    }

     void ChangeObjectMaterialP2()
    {
        renderer.material = newMaterialP2;
    }

    void ChangeMaterialBack()
    {
        renderer.material = passiveMaterial;
    }
}

