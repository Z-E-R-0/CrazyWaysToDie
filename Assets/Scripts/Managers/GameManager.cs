using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);

        }
    }


    public void StartGame()
    {
        Debug.Log("GameStarted");
        MiniGameManager.Instance.StartMiniGame();


    }
    public void EndGame()
    {

        Debug.Log("GameOver");
        // Call any GameOver UI Logic

    }
}
