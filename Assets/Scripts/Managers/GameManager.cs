using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static  GameManager Instance;
    private string[] miniGameScenes = {"MiniGame1"};
    private int currentMiniGameIndex = 0;
    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        Debug.Log("Game Started");
        LoadNextMiniGame();
    }

    public void LoadNextMiniGame()
    {
        if (currentMiniGameIndex < miniGameScenes.Length)
        {
            string sceneName = miniGameScenes[currentMiniGameIndex];
            StartCoroutine(LoadSceneAsync(sceneName));
            currentMiniGameIndex++;
        }
        else
        {
            Debug.Log("All mini-games completed.");
            // Handle end of game or restart
        }
    }

    private System.Collections.IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Get reference to the loaded scene's MiniGameManager and start the mini-game
        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(loadedScene);

        MiniGameManager miniGameManager = FindObjectOfType<MiniGameManager>();
        if (miniGameManager != null)
        {
            miniGameManager.StartMiniGame();
            miniGameManager.OnMiniGameCompleted += OnMiniGameCompleted;
            miniGameManager.OnMiniGameFailed += OnMiniGameFailed;
        }
    }

    private void OnMiniGameCompleted()
    {
        Debug.Log("Mini-game completed.");
        UnloadCurrentSceneAndLoadNext();
    }

    private void OnMiniGameFailed()
    {
        Debug.Log("Mini-game failed.");
        UnloadCurrentSceneAndLoadNext();
    }

    private void UnloadCurrentSceneAndLoadNext()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        StartCoroutine(UnloadSceneAsync(currentScene.name));
        LoadNextMiniGame();
    }

    private System.Collections.IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
    public void EndGame()
    {
        Debug.Log("Game Over");
        // Call any Game Over UI logic here
    }
}
