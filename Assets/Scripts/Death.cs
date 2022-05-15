using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject){
            if(gameManager.BoxScore>gameManager.highScore){
            PlayerPrefs.SetInt("BoxHighScore",gameManager.BoxScore);
            gameManager.highScore=PlayerPrefs.GetInt("BoxHighScore");
            }
            gameManager.highScoreText.gameObject.SetActive(true);
            gameManager.highScoreText.text="HighScore:"+gameManager.highScore;
            Time.timeScale=0;
            Invoke("gameOver",5);
        }   
    }
    void gameOver(){
        SceneManager.LoadScene(1);
    }
}
