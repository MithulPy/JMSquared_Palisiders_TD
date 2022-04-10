using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Wave_Manager waveManager;

    public bool gameOver = false;

    private void Start()
    {
        waveManager = GetComponent<Wave_Manager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            waveManager.StartWave();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            gameOver = true;
            Debug.Log("/---------Game Over-----------/");
        }
    }
}