using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeBar : MonoBehaviour
{
    public RectTransform fillRect;
    public RectTransform endRect;
    public Image fillColor;
    public Image fillAlpha;
    public Gradient gradient;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fillRect.localScale = new Vector3(gameManager.matchSeconds / gameManager.gameTime,1 ,1);
        fillColor.color = gradient.Evaluate(gameManager.matchSeconds / gameManager.gameTime);
    }
}
