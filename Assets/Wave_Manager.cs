using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(Wave_UI))]
public class Wave_Manager : MonoBehaviour
{
    private int currentWave = 0;
    private int enemiesInWave;
    private int enemiestoSpawn;

    private Wave_UI ui;

    private Timer timer;

    private GameManager manager;

    private List<Transform> spawners = new List<Transform>();

    public float spawnDelay;

    public float roundDelay;

    public int enemyIncreaseFactor;

    public GameObject enemy;


    private void Start()
    {
        manager = GetComponent<GameManager>();
        timer = GetComponent<Timer>();
        ui = GetComponent<Wave_UI>();

        ui.HideUI();

        foreach(Transform child in transform)
        {
            spawners.Add(child);
        }
    }

    public void StartWave()
    {
        if (manager.gameOver)
        {
            return;
        }

        currentWave += 1;

        enemiesInWave = enemyIncreaseFactor * currentWave;
        enemiestoSpawn = enemiesInWave;

        ui.UpdateUI(currentWave, enemiesInWave);

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemiestoSpawn; i++)
        {
            if (manager.gameOver)
            {
                break;
            }

            Instantiate(enemy, GetRandomSpawner(), Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void EndWave()
    {
        ui.HideUI();
        timer.StartTimer(roundDelay);
    }

    public void EnemyDied()
    {
        enemiesInWave -= 1;

        ui.UpdateUI(currentWave, enemiesInWave);

        if (enemiesInWave == 0)
        {
            EndWave();
        }
    }

    public Vector3 GetRandomSpawner()
    {
        return spawners[Random.Range(0, spawners.Count)].position;
    }
}