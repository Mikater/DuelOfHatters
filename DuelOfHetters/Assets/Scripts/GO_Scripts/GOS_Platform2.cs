using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOS_Platform2 : GOS_Base
{
    public float speed = 2f;
    public Vector3 moveToPoint;
    Vector3 Point1;
    Vector3 Point2;
    Vector3 PointCurrent;
    private void Start()
    {
        Point1 = transform.position;
        Point2 = Point1 + moveToPoint;
        PointCurrent = Point1;
    }
    private void Update()
    {
        if (buttonPushed)
            PointCurrent = Point2;
        else
            PointCurrent = Point1;
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, PointCurrent, speed * Time.deltaTime);
    
    }
}