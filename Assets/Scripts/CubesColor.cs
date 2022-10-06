using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesColor : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnMouseEnter()
    {
        switch (gameObject.tag)
        {
            case "Red":
                _meshRenderer.material.color = Color.red;
                break;
            case "Green":
                _meshRenderer.material.color = Color.green;
                break;
            case "Yellow":
                _meshRenderer.material.color = Color.yellow;
                break;
        }
    }

}
