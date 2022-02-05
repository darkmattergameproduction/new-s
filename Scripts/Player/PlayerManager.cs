using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;

    public GameObject startingText;

    public GameObject RateUsPanel;

    
    
    public Text CoinsText;
  


    public Text highScoreText;
    

    public Text score;
    public Text scoreForGame;


    public float scoreAmount;

    int highscore;

    

    public float pointIncreasedPerSecond;



    public static int numberOfCoins;
    public static int point;
    public static PlayerManager instance;

    private void awake()
    {
        instance = this;


    }


        // Start is called before the first frame update
        void Start()
    {
        
        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
        numberOfCoins = PlayerPrefs.GetInt("numberOfCoins");

        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;


        

        highScoreText.text = PlayerPrefs.GetInt("highscore").ToString();


    }

    // Update is called once per frame
    void Update()
    {

       if(gameOver)
        {
           

           


            StartCoroutine(stopafterdeath());

            isGameStarted = false;

           

        }

        CoinsText.text = "" + PlayerPrefs.GetInt("numberOfCoins");
       
        

        score.text = "score:" + (int)scoreAmount + point;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

       

        highscore = (int)scoreAmount + point;

        PlayerPrefs.SetInt("highscore", highscore);
        score.text = "" + PlayerPrefs.GetInt("highscore");
        scoreForGame.text = "" + PlayerPrefs.GetInt("highscore");

        if (highscore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", highscore);
            highScoreText.text = highscore.ToString();

        }

            
     



        if (SwipeManager.tap && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
           
    
            
            
        }
       
        
     
        
    }

    




    private IEnumerator stopafterdeath()
    {

        

        yield return new WaitForSeconds(1.8f);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        

        if(numberOfCoins > 5000)
        {
            if (Random.Range(0, 20) == 0)
            {
                RateUsPanel.SetActive(true);

            }
           


        }












    }




}
