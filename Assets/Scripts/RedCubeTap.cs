using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeTap : MonoBehaviour
{
    public static RedCubeTap Instance;

    //public enum WhichCube
    //{
    //    RED,
    //    GREEN,
    //    YELLOW,
    //}
    //public WhichCube whichCube;

    private void Awake()
    {
        Instance = this;
    }

    private void OnMouseDown()
    {
        switch (gameObject.tag)
        {
            case "FirstRedCube":
                DrawLine.Instance.whichCubetapped = DrawLine.WhichCubeTapped.RED;
                break;

            case "GreenBase":
                DrawLine.Instance.whichCubetapped = DrawLine.WhichCubeTapped.GREEN;
                break;

            case "YellowBase":
                DrawLine.Instance.whichCubetapped = DrawLine.WhichCubeTapped.YELLOW;
                break;

                default: DrawLine.Instance.whichCubetapped = DrawLine.WhichCubeTapped.WHITE;
                break;
        }
    }
    private void OnMouseEnter()
    {
        if (gameObject.CompareTag("FirstRedCube"))
        {
            GameManager.Instance.firstRedCube = true;
        }
        if (gameObject.CompareTag("SecondRedCube"))
        {
            GameManager.Instance.secondRedCube = true;
        }
    }
    private void Update()
    {
        if (GameManager.Instance.firstRedCube && GameManager.Instance.secondRedCube)
        {
            GameManager.Instance.redCubeFinalCheck =true; 
        }
    }
}
