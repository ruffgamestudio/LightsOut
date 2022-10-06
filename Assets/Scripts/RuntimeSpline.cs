using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSpline : MonoBehaviour
{
    public RedLight redlight;
    public RedLight greenLight;
    public RedLight yellowLight;

    public void CreateSpline(List<Vector3> poses)
    {
        if (GetComponent<SplineComputer>() != null) Destroy(GetComponent<SplineComputer>());
       
        SplineComputer spline = gameObject.AddComponent<SplineComputer>();
        //Create a new array of spline points
        SplinePoint[] points = new SplinePoint[poses.Count];
        //Set each point's properties
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new SplinePoint();
            points[i].position = poses[i];
            points[i].normal = Vector3.up;
            points[i].size = 1f;
            points[i].color = Color.white;
        }
        //Write the points to the spline
       
        spline.SetPoints(points);
        spline.sampleRate =30;
        redlight.FollowSpline(spline);
    }



}
