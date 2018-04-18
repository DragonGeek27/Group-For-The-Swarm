<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject pollen;
    public int scoreValue;

    private GameController gameController;
    private Quaternion polRotation = new Quaternion();

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Pollen"))
        {
            return;
        }

        if (gameObject.CompareTag("Pollen") && other.CompareTag("Bolt"))
        {
            return;
        }

        if (gameObject.CompareTag("Pollen") && other.CompareTag("Player"))
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);                        
            return;
        }

        
        
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(pollen, gameObject.transform.position, polRotation);
        }

        if (other.CompareTag("Player") && !gameObject.CompareTag("Pollen"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        //gameController.AddScore(scoreValue);
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject pollen;
    public int scoreValue;

    private GameController gameController;
    private Quaternion polRotation = new Quaternion();

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Pollen"))
        {
            return;
        }

        if (gameObject.CompareTag("Pollen") && other.CompareTag("Bolt"))
        {
            return;
        }

        if (gameObject.CompareTag("Pollen") && other.CompareTag("Player"))
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);                        
            return;
        }

        
        
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(pollen, gameObject.transform.position, polRotation);
        }

        if (other.CompareTag("Player") && !gameObject.CompareTag("Pollen"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        //gameController.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject);

    }
>>>>>>> caf0446533c6fc341b9a9688902caa724171bdda
}