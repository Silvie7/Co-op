using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class CursorManager : MonoBehaviour
{
    public GameObject cursorP1;
    public GameObject cursorP2;
    public GameObject cursorCenter;

    public LayerMask layerMask;
    public float allowedDistance;
    public float joystickSpeed = 1;

    //public List <GameObject> targets = new List <GameObject>();
    public List<float> distances = new List<float>();
    public float lowestDistance;
    public GameObject target;
    public bool canSelect = true;
    public bool showCursors = true;

    void Start()
    {
        target = cursorCenter;
    }

    void Update()
    {
        CursorMovement();
        HandleCursorCenter();
        //if (canSelect)
        //{
        //    SelectTarget();
        //}
        //else 
        //{
        //    target = null;
        //}

    }
    void CursorMovement() 
    {
        //Cursor Player 1 (controller)
        Vector2 input = new Vector2(Input.GetAxis("P1CR_Horizontal"), Input.GetAxis("P1CR_Vertical"));
        Debug.Log("right stick " + input);
        cursorP1.transform.position += new Vector3(0, input.y * (joystickSpeed * 0.1f), input.x * (joystickSpeed * 0.1f));

        //Cursor Player 2 (mouse)
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            var targetPosition = hit.point;
            cursorP2.transform.position = targetPosition;
        }
    }
    void HandleCursorCenter() 
    {
        //Find center between cursors
        var centerPosition = Vector3.Lerp(cursorP1.transform.position, cursorP2.transform.position, 0.5f);
        cursorCenter.transform.position = centerPosition;

        //Disable center when cursors are too far away from each other
        if (Vector3.Distance(cursorP1.transform.position, cursorP2.transform.position) > allowedDistance)
        {
            cursorCenter.SetActive(false);
            canSelect = false;
        }
        else if (!cursorCenter.activeSelf)
        {
            cursorCenter.SetActive(true);
            canSelect = true;
        }
    }
    //void SelectTarget() 
    //{
    //    //foreach (GameObject obj in targets) 
    //    //{
    //    //    if (Vector3.Distance(obj.transform.position, cursorCenter.transform.position) < 2) 
    //    //    {
    //    //        target = obj;   
    //    //    }
    //    //}

    //    for (int i = 0; i < targets.Count; i++) 
    //    {
    //        distances[i] = Vector3.Distance(targets[i].transform.position, cursorCenter.transform.position);
    //    }

    //    lowestDistance = distances.Min();

    //    for (int i = 0; i < distances.Count; i++)
    //    {
    //        if (distances[i] == lowestDistance) 
    //        {
    //            target = targets[i];
    //        }
    //    }
    //}
}
