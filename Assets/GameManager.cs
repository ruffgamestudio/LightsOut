using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool firstRedCube, secondRedCube, redCubeFinalCheck;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       //StopTheCars();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //public async void StopTheCars()
    //{
    //    await Task.Delay(5000);
    //    EventManager.StopTheCars();
    //    EventManager.StopTheCamera();
    //}

    //public void PlayTheCars()
    //{
    //    EventManager.PlayTheCars();
    //    EventManager.PlayTheCamera();
    //}
}
