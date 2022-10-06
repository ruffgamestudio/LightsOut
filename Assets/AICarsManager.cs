using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AICarsManager : MonoBehaviour
{
    private List<AICarController> _aICars;

    //private void Awake()
    //{
    //    _aICars = new List<AICarController>();
    //    _aICars.AddRange(GameObject.FindObjectsOfType<AICarController>());
    //}
    //private void OnEnable()
    //{
    //    EventManager.StopTheCars += () => StopTheCars();
    //    EventManager.PlayTheCars += () => PlayTheCars();
    //}
    //private void OnDisable()
    //{
    //    EventManager.StopTheCars = null;
    //    EventManager.PlayTheCars = null;
    //}


    //public void StopTheCars()
    //{
    //    foreach (var item in _aICars)
    //    {
    //        item.speed = 0;
    //    }
    //}

    //public void PlayTheCars()
    //{
    //    foreach (var item in _aICars)
    //    {
    //        item.speed = 3;
    //    }
    //}
}
