using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    private void Awake()
    {
        //List<Transform> points = new List<Transform>();
        //foreach (Transform child in transform)
        //{
        //    points.Add(child.transform);
        //}

        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}