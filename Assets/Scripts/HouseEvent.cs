using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{

    [SerializeField] private Animator _redAnimator;
    [SerializeField] private Animator _greenAnimator;
    [SerializeField] private Animator _yellowAnimator;

    [SerializeField] private Animator[] _childAnimator;

    [SerializeField] private Material _redMaterial, _greenMaterial, _yellowMaterial;

    public float colorIndex=4;

    [ContextMenu("DOIT")]
    public void RedGlow()
    {
        _redMaterial.SetColor("_EmissionColor", Color.red * colorIndex);
        colorIndex*=10; 
    }
    public void GreenGlow()
    {

    }
    public void YellowGlow()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _redAnimator.enabled = true;
            _greenAnimator.enabled=true;
            _yellowAnimator.enabled=true;
            foreach (var item in _childAnimator)
            {
                item.SetBool("CanRun", true);
            }


        }
    }
}
