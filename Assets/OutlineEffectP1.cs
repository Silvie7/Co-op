using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineEffectP1 : MonoBehaviour
{
    public Material outlineMaterial;
    private LineRenderer lineRendererP1;
     private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        lineRendererP1 = gameObject.AddComponent<LineRenderer>();
        lineRendererP1.material = outlineMaterial;
        lineRendererP1.startWidth = 0.1f;
        lineRendererP1.endWidth = 0.1f;
        lineRendererP1.numCapVertices = 2;
        lineRendererP1.useWorldSpace = false;
        lineRendererP1.enabled = false;
        lineRendererP1.positionCount = mesh.vertexCount;

        
        Vector3[] vertices = mesh.vertices;
        lineRendererP1.SetPositions(vertices);
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
