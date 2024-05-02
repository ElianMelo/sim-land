using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Paused,
    Playing
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState currentState = GameState.Playing;

    private void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        currentState = GameState.Paused;
    }

    public void ResumeGame()
    {
        currentState = GameState.Playing;
    }

    public GameState GetGameState()
    {
        return currentState;
    }
}
