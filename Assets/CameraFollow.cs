using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _camSpeed=6;

    //private void OnEnable()
    //{
    //    EventManager.StopTheCamera+=()=>_camSpeed=0;
    //    EventManager.PlayTheCamera+=()=>_camSpeed=3;
    //}
    //private void OnDisable()
    //{
    //    EventManager.StopTheCamera = null;
    //    EventManager.PlayTheCamera = null;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.position += Vector3.forward * _camSpeed * Time.deltaTime;
    //}
}
