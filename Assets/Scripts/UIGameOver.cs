using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;

    Board board;

    UIPoints uiPoints;

    private void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();
        uiPoints = GameObject.Find("UI").transform.GetChild(0).GetComponent<UIPoints>();
    }

    private void Update()
    {
        pointsText.text = GameManager.Instance.points.ToString() + " Points";
    }

    public void PlayAgain()
    {
        GameManager.Instance.points = 0;
        uiPoints.displayedPoints = 0;
        uiPoints.pointsLabel.text = "0";
        GameManager.Instance.matchSeconds = GameManager.Instance.gameTime;
        GameManager.Instance.gameState = GameManager.GameState.InGame;
        board.ClearAllPieces();
        board.Start();
        GameManager.Instance.currentSecondsForMatchStart = GameManager.Instance.secondsForMatchStart;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
