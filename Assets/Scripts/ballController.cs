using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float upForce;
    Rigidbody2D rb;
    bool started;
    bool gameOver;
    public float ballRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();    
        started = false ;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started){
            //touch happen
            if(Input.GetMouseButtonDown(0)){
                started = true;
                rb.isKinematic = false;
                GameManager.instance.GameStart();
            }
        }
        else if(started && !gameOver){
            transform.Rotate(0,0,ballRotation);
            if(Input.GetMouseButtonDown(0)){
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        gameOver =  true;
        GameManager.instance.GameOver();
    }

     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "pipe" && !gameOver) {
            gameOver = true;
            Debug.Log("collide Pipe");
            GameManager.instance.GameOver();
            AudioManager.instance.Play("collide");
            
        }
        
        if(other.gameObject.tag == "ScoreChecker" && !gameOver){
            ScoreManager.instance.IncrementScore();
            AudioManager.instance.Play("score");

        }
    }
}
