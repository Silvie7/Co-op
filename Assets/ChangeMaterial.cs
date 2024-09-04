using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial;
    public Material passiveMaterial;
    public bool changeMat;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeMat)
        {
            ChangeObjectMaterial();
            changeMat = false;
            
        }
        else
        {
            ChangeMaterialBack();
        }
    }
    

    void ChangeObjectMaterial()
    {
        renderer.material = newMaterial;
    }
    void ChangeMaterialBack()
    {
        renderer.material = passiveMaterial;
    }
}

