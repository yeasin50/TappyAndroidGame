using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance; 
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject startUi;
    public Text highScore;

    private void Awake() {
        if(instance==null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  ScoreManager.instance.score.ToString();         
    }


    public void GameStart(){
        startUi.SetActive(false);
    }

    public void GameOver(){
        int hscore=  PlayerPrefs.GetInt("HighScore");
        Debug.Log(hscore);
        highScore.text = hscore.ToString();
        gameOverPanel.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("level1");
         AudioManager.instance.Stop("gameOver");
         AudioManager.instance.Play("startClip");
    }

    public void GameMenu(){
        SceneManager.LoadScene("Menu");
        AudioManager.instance.Stop("gameOver");
        AudioManager.instance.Play("startClip");
    }
}
