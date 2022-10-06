using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [HideInInspector]
    public LineRenderer lineRenderer;

    private RedLight redLight;

    public RuntimeSpline RuntimeSpline;

    private List<Vector3> positions=new List<Vector3>();
    private List<Vector3> redLightList=new List<Vector3>();
    private List<Vector3> greenLightList = new List<Vector3>();
    private List<Vector3> yellowLightList = new List<Vector3>();
    private int temp=0;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        redLight = GameObject.FindObjectOfType<RedLight>();
        RuntimeSpline=GameObject.FindObjectOfType<RuntimeSpline>();
    }
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{a
        //    positions.Clear();
        //}
        if (Input.GetKeyUp(KeyCode.Mouse0)/*&&GameManager.Instance.redCubeFinalCheck*/)
        {
            GameManager.Instance.redCubeFinalCheck=false;
            redLightList = positions;
            RuntimeSpline.CreateSpline(positions);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            
        }
    }


    public void SetPositions(Vector3 pos,bool keyUp)
    {
        if (keyUp&&(temp-1)%4!=0)
        {         
            positions.Add(pos);
        }
        else
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
            if (temp % 4 == 0)
            {            
                positions.Add(pos);
            }
            temp++;
        }

       
    }
}
