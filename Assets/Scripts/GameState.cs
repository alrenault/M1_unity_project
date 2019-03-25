using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static GameState instance = null;
    private int scorePlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        scorePlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScorePlayer(int toAdd)
    {
        scorePlayer += toAdd;
    }

    public int getScorePlayer()
    {
        return scorePlayer;
    }

    private void FixedUpdate()
    {
        GameObject.FindGameObjectWithTag("scoreLabel").GetComponent<Text>().text = "" + scorePlayer;
    }
}
