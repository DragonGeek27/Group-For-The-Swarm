using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    float timeCounter = 0;
    float speed = 10;
    public Transform target;
    public float RotationSpeed = 100f;
    public float OrbitDegrees = 1f;

    private void Start()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.up, OrbitDegrees);
    }


}