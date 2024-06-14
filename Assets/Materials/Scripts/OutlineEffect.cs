using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineEffect : MonoBehaviour
{
    public Material outlineMaterial;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = outlineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.numCapVertices = 2;
        lineRenderer.useWorldSpace = false;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    public void EnableOutline()
    {
        lineRenderer.enabled = true;
    }

    public void DisableOutline()
    {
        lineRenderer.enabled = false;
    }
}
