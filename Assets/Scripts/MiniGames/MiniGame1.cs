using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MiniGameBase
{
    public override void StartMiniGame()
    {
        Debug.Log("MiniGame1Started");
        bool success = Random.value > 0.5f;

        if(success)
        {
            CompleteMiniGame();

        }
        else
        {

            FailMiniGame();

        }
    }
}
