using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Transform EnemyPrimaryTarget;
    public Transform EnemySecondaryTarget;

    public EnemySpawner[] spawnPoints;
    public int spawnAmount = 10;
    public float spawnInterval = 0.2f;

    public int life = 10;
    public int health = 100;
    public int score = 0;

    public int wave = 1;
    public float waveTimer = 4.0f;
    public int enemiesRemaining;

    public Text livesText;
    public Text healthText;
    public Text scoreText;

    private float timer;
    private float wTimer;

    // Use this for initialization
    void Start() {
        timer = spawnInterval;
        wTimer = waveTimer;
        enemiesRemaining = spawnAmount;
    }

    // Update is called once per frame
    void Update() {
        if (timer <= 0 && spawnAmount > 0) {
            int rando = Random.Range(0, spawnPoints.Length - 1);
            if (spawnPoints[rando] != null) {
                spawnPoints[rando].Spawn();
                spawnAmount--;
            }
            timer = spawnInterval;
            wTimer = waveTimer;
        } else {
            timer -= 1 * Time.deltaTime;
        }

        if (life <= 0) {
            livesText.text = "Your crown is taken";
        } else {
            livesText.text = life.ToString();
        }

        if (health <= 0) {
            healthText.text = "You have met an unfortunate end";
        } else {
            healthText.text = health.ToString();
        }
        scoreText.text = score.ToString();

        // waves
        if (enemiesRemaining <= 0) {
            if (wTimer <= 0) {
                wave++;
                spawnAmount = (wave * 3) + 10;
                wTimer = waveTimer;
                enemiesRemaining = spawnAmount;
            } else {
                wTimer -= 1 * Time.deltaTime;
            }
        }
    }
}
