using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatform : MonoBehaviour
{
    private Vector3 LocationA;
    private Vector3 LocationB;
    private Vector3 NextLocation;

    [SerializeField] private Transform platform;
    [SerializeField] private Transform MovingToLocation;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        LocationA = platform.localPosition;
        LocationB = MovingToLocation.localPosition;
        NextLocation = LocationB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        platform.localPosition = Vector3.MoveTowards(platform.localPosition, NextLocation, speed * Time.deltaTime);

        if (Vector3.Distance(platform.localPosition,NextLocation) <= 0.1)
        {
            ChangePosition();
        }
    }

    private void ChangePosition()
    {

        NextLocation = NextLocation != LocationA ? LocationA : LocationB; // If Not A, then B, if not b, then A

    }



}
