using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.audioSource.Play();
        Invoke("StateChange", 1);
    }
    public void StateChange()
    {
        GameManager.Instance.gameState = GameManager.GameState.InGame;
    }
}
