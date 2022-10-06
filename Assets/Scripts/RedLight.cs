using DG.Tweening;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedLight : MonoBehaviour
{

    public List<Vector3> positions;

    public GameObject hitVFX;


    public void FollowSpline(SplineComputer spline)
    {
        if (GetComponent<SplineFollower>()!=null)
        {
            Destroy(GetComponent<SplineFollower>());
        }
       SplineFollower splineFollower=transform.AddComponent<SplineFollower>();
        splineFollower.spline = spline;
        splineFollower.updateMethod = SplineUser.UpdateMethod.FixedUpdate;
        splineFollower.physicsMode = SplineTracer.PhysicsMode.Rigidbody;
        splineFollower.followSpeed =4;
        splineFollower.enabled = true;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            GetComponent<SplineFollower>().enabled = false;
            Instantiate(hitVFX, collision.contacts[0].point, Quaternion.identity);
           // GetComponent<Rigidbody>().AddExplosionForce(5000, collision.contacts[0].point, 5);
            GetComponent<Rigidbody>().AddForce(new Vector3(-transform.forward.x,Random.Range(0,1), -transform.forward.z) * 70, ForceMode.Impulse);
        }
    }
}
