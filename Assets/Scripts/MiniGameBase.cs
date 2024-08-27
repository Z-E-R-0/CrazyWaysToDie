using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameBase : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void StartMiniGame();

    protected void CompleteMiniGame()
    {
        Debug.Log("MiniGameCompleted");
        MiniGameManager.Instance.StartNextMiniGame();

    }
    protected void FailMiniGame()
    {
        Debug.Log("MiniGameFailed");
        GameManager.Instance.EndGame();

    }
}
