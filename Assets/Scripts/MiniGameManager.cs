using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;
    public List<MiniGameBase> miniGamesList;
    private int currentMiniGameIndex = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        miniGamesList = new List<MiniGameBase>(FindObjectsOfType<MiniGameBase>());
        ShuffleMiniGames();
    }
    public void StartMiniGame()
    {
        currentMiniGameIndex = 0;
        StartNextMiniGame();


    }
   
    public void StartNextMiniGame()
    {
        if(currentMiniGameIndex <miniGamesList.Count)
        {
            miniGamesList[currentMiniGameIndex].StartMiniGame();
            currentMiniGameIndex++;


        }
        else
        {
            EndSequence();
        }


    }
    public void ShuffleMiniGames()
    {
        for(int i = miniGamesList.Count-1; i < 0; i--)
        {

            int rand = Random.Range(0, i);
            var temp = miniGamesList[i];
            miniGamesList[i] = miniGamesList[rand];
            miniGamesList[rand] = temp;

        }


    }
    private void EndSequence()
    {
        GameManager.Instance.EndGame();


    }
}
