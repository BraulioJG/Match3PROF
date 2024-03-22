using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPoints : MonoBehaviour
{
    public int displayedPoints;
    public TextMeshProUGUI pointsLabel;

    private void Start()
    {
        GameManager.Instance.OnPointsUpdated.AddListener(UpdatedPoints);
    }

    public void UpdatedPoints()
    {
        StartCoroutine("UpdatedPointsCoroutine");
    }

    IEnumerator UpdatedPointsCoroutine()
    {
        while(displayedPoints < GameManager.Instance.points)
        {
            displayedPoints++;
            pointsLabel.text = displayedPoints.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
