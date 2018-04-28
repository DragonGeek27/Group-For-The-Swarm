using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossBehavior : MonoBehaviour {
    public Transform target;
    public float forwardSpeed;
    public GameObject explosion;

    public float rightLimit = 2.5f;
    public float leftLimit = 1.0f;
    public float speed = 2.0f;
    private int direction = 1;
    public float delta = 1.5f;  // Amount to move left and right from the start point
                                // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    public bool isHere = false;
    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;
    public GameObject collide;
    private Vector3 startPos;
    public Image healthBar;
    public int bossHealth;
    private float birdHealth = 10;
    private static int maxHealth = 50;
    private static int pleaseWork = 50;
    public void Start()
    {
        bossHealth = 100;
        startPos = transform.position;
        birdHealth = 10;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 target = new Vector3(0, 0, 13);
        transform.rotation = Quaternion.Euler(0, -180, 0);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bolt")
        {
            pleaseWork--;
            healthBar.fillAmount = (float)pleaseWork / (float)maxHealth;
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log(pleaseWork);
            if (pleaseWork == 0)
            {
                birdHealth = bossHealth;
                Destroy(this.gameObject);
                Debug.Log(birdHealth + ", " + bossHealth);
            }
        }
    }
    public bool isDestroyed()
    {
        if (pleaseWork == 0)
        {
            Debug.Log("PLEASE!");
            pleaseWork = 100;
            return true;
        }
        else
        {
            Debug.Log(pleaseWork);
            return false;
        }
    }
}
