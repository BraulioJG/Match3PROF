using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;

    private void Update()
    {
        pointsText.text = GameManager.Instance.points.ToString() + " Points";
    }

    public void PlayAgain()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
