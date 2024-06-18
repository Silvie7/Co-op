using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineEffectP1 : MonoBehaviour
{
    public Material outlineMaterialP1;
    private LineRenderer lineRendererP1;
     private Mesh meshP1;

    // Start is called before the first frame update
    void Start()
    {
        meshP1 = GetComponent<MeshFilter>().mesh;
        lineRendererP1 = gameObject.AddComponent<LineRenderer>();
        lineRendererP1.material = outlineMaterialP1;
        lineRendererP1.startWidth = 0.1f;
        lineRendererP1.endWidth = 0.1f;
        lineRendererP1.numCapVertices = 2;
        lineRendererP1.useWorldSpace = false;
        lineRendererP1.enabled = false;
        lineRendererP1.positionCount = meshP1.vertexCount;

        
        Vector3[] verticesP1 = meshP1.vertices;
        lineRendererP1.SetPositions(verticesP1);
    }

    // Update is called once per frame
    public void EnableOutlineP1()
    {
        lineRendererP1.enabled = true;
    }

    public void DisableOutlineP1()
    {
        lineRendererP1.enabled = false;
    }

    
}
