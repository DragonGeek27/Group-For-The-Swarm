using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;//Joystick

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundry;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private AudioSource audioSource;

    //Joystick
    private Rigidbody2D myBody;
    //public GameObject shot2;

    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();


    }
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //           GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
            audioSource.Play();
        }
    }
    void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

          //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 moveVec = new Vector3
              (CrossPlatformInputManager.GetAxis("Horizontal"),0,
              CrossPlatformInputManager.GetAxis("Vertical"));

        rb.velocity = moveVec * speed;
       
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        //Joystick
       
        //bool isShooting = CrossPlatformInputManager.GetButton("Shoot");

        
    }
}
