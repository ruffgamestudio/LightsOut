using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public static DrawLine Instance;
    private Line currentLine;

    [SerializeField] private Line linePrefab;

    private Camera mainCam;

    private int layerMask = 1 << 6;

    [SerializeField] private float coolDown;

    private float timer;

    public float _fixedDistance = 1.079995f;
    private float _hitDist, t;

    [SerializeField] private Plane _movePlane;

    private Vector3 _startPos, _point, _corPoint;

    private Ray _camRay;

    private Vector3 lastPos;

    [SerializeField] private Transform ground;

    [SerializeField] private Material[] _materials;

    private float lineWidht = .12f;

    public enum WhichCubeTapped
    {
        GREEN,
        YELLOW,
        RED,
        WHITE,
    }

    public WhichCubeTapped whichCubetapped;

    private int _whichMaterial;
    private void Awake()
    {
        Instance = this;
        mainCam = Camera.main;
    }

    void Update()
    {
        if (whichCubetapped == WhichCubeTapped.RED) _whichMaterial = 0;
        if (whichCubetapped == WhichCubeTapped.GREEN) _whichMaterial = 1;
        if (whichCubetapped == WhichCubeTapped.YELLOW) _whichMaterial = 2;
        if (whichCubetapped == WhichCubeTapped.WHITE) _whichMaterial = 3;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (GameObject.FindGameObjectWithTag("Line") != null) 
  
            timer = 100;
            _movePlane = new Plane(-Camera.main.transform.forward, ground.position);


            _camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

            if (_movePlane.Raycast(_camRay, out _hitDist))
            { // finde the collision on movePlane
                _point = _camRay.GetPoint(_hitDist); // define the point on movePlane
                t = -(_fixedDistance - _camRay.origin.y) / (_camRay.origin.y - _point.y); // the x,y or z plane you want to be fixed to
                _corPoint.x = _camRay.origin.x + (_point.x - _camRay.origin.x) * t; // calculate the new point t futher along the ray
                _corPoint.y = _camRay.origin.y + (_point.y - _camRay.origin.y) * t;
                _corPoint.z = _camRay.origin.z + (_point.z - _camRay.origin.z) * t;
                currentLine = Instantiate(linePrefab, _corPoint, Quaternion.identity);
                currentLine.SetPositions(_corPoint,false);
                lastPos = _corPoint;
                currentLine.GetComponent<LineRenderer>().startWidth = lineWidht;
                currentLine.GetComponent<LineRenderer>().endWidth = lineWidht;
                currentLine.GetComponent<LineRenderer>().material = _materials[_whichMaterial];
            }

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // timer += Time.deltaTime;

            timer = 0;

            _camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

            if (_movePlane.Raycast(_camRay, out _hitDist))
            { // finde the collision on movePlane
                _point = _camRay.GetPoint(_hitDist); // define the point on movePlane
                t = -(_fixedDistance - _camRay.origin.y) / (_camRay.origin.y - _point.y); // the x,y or z plane you want to be fixed to
                _corPoint.x = _camRay.origin.x + (_point.x - _camRay.origin.x) * t; // calculate the new point t futher along the ray
                _corPoint.y = _camRay.origin.y + (_point.y - _camRay.origin.y) * t;
                _corPoint.z = _camRay.origin.z + (_point.z - _camRay.origin.z) * t;
             
                if (Vector3.Distance(lastPos, _corPoint) > .7f)
                {
                    currentLine.SetPositions(_corPoint,false);
                    lastPos = _corPoint;
                }

            }



        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
         currentLine.SetPositions(_corPoint,true);
         lastPos = _corPoint;
            //if (!GameManager.Instance.redCubeFinalCheck)
            //{
            //    GameManager.Instance.redCubeFinalCheck = false;
            //    Destroy(GameObject.FindGameObjectWithTag("Line"));
            //}
            //GameObject.FindObjectOfType<CarController>().GetComponent<AICarController>().enabled = false;
            //GameManager.Instance.PlayTheCars();             
        }
    }
}
