﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject signInMenu;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject bossPrefab;

    public Text scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText mainMenuText;
    private BossBehavior script;

    private bool gameOver;
    private bool restart;
    private bool mainMenu;
    private int score;
    public int _score;
    private bool bossBattle;
    private int bossCount;

    void Start()
    {
        gameOver = false;
        bossCount = 1;
        restart = false;
        mainMenu = false;
        restartText.text = "";
        gameOverText.text = "";
        mainMenuText.text = "";
        signInMenu.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        script = bossPrefab.GetComponent<BossBehavior>();
    }

    void Update()
    {
        //if (restart)
        //{
        //    Restart();
        //}

        if (script.isDestroyed())
        {
            bossCount++;
            score += 250;
            Debug.Log("What's the deal?");
            StartCoroutine(SpawnWaves());
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (score / (1000 * bossCount) != 1)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                bossBattle = false;
            }
            yield return new WaitForSeconds(waveWait);
        }
        if (score / (1000 * bossCount) == 1)
        {
            bossBattle = true;
            spawnBoss();
        }
    }

    public void spawnBoss()
    {
        GameObject go = bossPrefab;
        Vector3 boss = new Vector3(0, 0, 30);
        Instantiate(go, boss, transform.rotation);

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        _score = score;
        scoreText.text = "Pollen Count: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        restartText.text = "Try Again";
        restart = true;
        mainMenuText.text = "Start Screen";
        mainMenu = true;
        signInMenu.SetActive(true);
    }

    //public void Restart()
    //{
    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        Application.LoadLevel(Application.loadedLevel);
    //    }
    //}
}