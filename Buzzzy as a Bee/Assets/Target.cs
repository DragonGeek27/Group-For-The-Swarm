using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;

    float timeCounter = 0;
    float speed = 10;
    public Transform target;
    public float RotationSpeed = 100f;
    public float OrbitDegrees = 1f;

    private void Start()
    {
        _centre = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.up, OrbitDegrees);
    }


}