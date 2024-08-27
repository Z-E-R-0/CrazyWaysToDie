using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MiniGameBase
{
    public GameObject character;
    public GameObject train;
    public float trainSpeed = 5f;
    public float gameDuration = 5f;
    private Vector3 characterStartPos;
    private bool gameStarted = false;

    private void Start()
    {
        characterStartPos = character.transform.position;
        StartMiniGame();
    }

    public override void StartMiniGame()
    {
        Debug.Log("MiniGame1Started : Avoid the Train Mini-Game Started");
        gameStarted = true;
        train.transform.position = new Vector3(-10, train.transform.position.y, 0);
        StartCoroutine(EndGameAfterTime(gameDuration));
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

    private void Update()
    {
        if (!gameStarted) return;
       
        train.transform.Translate(Vector3.right * trainSpeed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            character.transform.position = new Vector3(mousePos.x, mousePos.y, 0);


        }
        if(train.transform.position.x >= character.transform.position.x)
        {

            FailMiniGame();
        }
    }
    private System.Collections.IEnumerator EndGameAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        FailMiniGame(); // Game ends if time runs out and the player hasn't escaped
    }
}
