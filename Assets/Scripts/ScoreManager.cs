using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance ;
    public int score;
    // Start is called before the first frame update
    
    private void Awake() {
        if(instance==null){
            instance = this;
        }    
    }
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void IncrementScore(){
       score++;
       Debug.Log("Score "+ score.ToString());
    }

    public void StopScore(){

        if(PlayerPrefs.HasKey("HighScore")){
            if(score> PlayerPrefs.GetInt("HighScore")){
                PlayerPrefs.SetInt("HighScore", score);
            }
        }else{
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    
}
