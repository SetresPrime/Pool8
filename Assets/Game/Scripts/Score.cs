using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text VOL;

    void OnTriggerEnter(Collider collider)
    {
        if (score != 14 && (collider.gameObject.name == "8" || collider.gameObject.name == "White Ball"))
        {
            score = 0;
            GameEnd("Поражение", Color.red);
        }
        else if (score == 15 && collider.gameObject.name == "White Ball")
            GameEnd("Победа", Color.green);

        else
            score++;

        collider.gameObject.SetActive(false);

        scoreText.text = score.ToString() ; 
    }
    void GameEnd(string text, Color _color) 
    { 
        VOL.gameObject.SetActive(true);
        VOL.color = _color;
        VOL.text = text;
        Time.timeScale = 0;
    }
}
