using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver;

    private void Awake() {

        DontDestroyOnLoad(this.gameObject);

        if(instance==null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = true;
        AudioManager.instance.Play("startClip");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(){
        UiManager.instance.GameStart();
        AudioManager.instance.Stop("startClip");
        AudioManager.instance.Play("theme");
        AudioManager.instance.Stop("gameOver");
        GameObject.Find("PipeSpawner").GetComponent<pipeSpawner>().StartSpawningPipe();
    }

    public void GameOver(){
        gameOver = false;
        GameObject.Find("PipeSpawner").GetComponent<pipeSpawner>().StopSpawningPipe();
        ScoreManager.instance.StopScore();
        UiManager.instance.GameOver();

        AudioManager.instance.Stop("theme");
        AudioManager.instance.Play("gameOver");
        
    }
}
