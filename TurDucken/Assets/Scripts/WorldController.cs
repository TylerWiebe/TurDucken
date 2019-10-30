using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    private float timeLeft = 60f;
    private bool BetweenGames = true;
    public Text timerText;
    private GameObject farmer;
    private GameObject chicken;
    public Sprite StartMenuSprite;
    public Sprite ChickenWinSprite;
    public Sprite FarmerWinSprite;
    private FarmerController fs;
    private ChickenController cs;

    private void Start()
    {
        farmer = GameObject.Find("Crosshair");
        chicken = GameObject.Find("Chicken");
        winBanners(true, false);

        fs = farmer.GetComponent<FarmerController>();
        cs = chicken.GetComponent<ChickenController>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!BetweenGames)
        {
            timeLeft -= Time.deltaTime;
            //checkwin for farmer
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                BetweenGames = true;
                pauseGame();
                winBanners(false, false);
            }
            timerText.text = timeLeft.ToString();


            //Check win for chicken hit.
            if (fs.getChickenHit())
            {
                pauseGame();
                winBanners(false, true);
                BetweenGames = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

       
    }



    private void pauseGame()
    {
        fs.setGameGoing(false);
        cs.setGameGoing(false);
        BetweenGames = true;

    }

    private void resumeGame()
    {
        cs.setGameGoing(true);
        fs.setGameGoing(true);
    }

    //resets the game
    private void restartGame()
    {
        cs.ResetChicken();
    }
    //one object that slides up into the cameral view
    //change the sprite to match the winner
    private void winBanners(bool startMenu, bool ChickenWin)
    {
        GameObject WinBanner = GameObject.Find("WinBanner");
        if (startMenu)
        {
            WinBanner.GetComponent<SpriteRenderer>().sprite = StartMenuSprite;
        }
        else
        { 
            if (ChickenWin)
            {
                Debug.Log("Chicken Win");
                WinBanner.GetComponent<SpriteRenderer>().sprite = ChickenWinSprite;
            }
            else
            {
                Debug.Log("Farmer Win");
                WinBanner.GetComponent<SpriteRenderer>().sprite = FarmerWinSprite;
            }

        }
    }

    //an overlay
    private void StartGame()
    {
        DelayFunction();
        cs.ResetChicken();
        fs.ResetCrosshair();
        timeLeft = 60;
        resumeGame();
        BetweenGames = false;
    }

    IEnumerator DelayFunction()
    {
        yield return new WaitForSeconds(3);
    }
}
