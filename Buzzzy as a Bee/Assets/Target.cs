using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public Transform target;
    public float RotationSpeed = 0f;
    public float OrbitDegrees = 0f;

    private void Start()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.up, OrbitDegrees);
    }


}