using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    private float timeLeft = 60f;
    private bool timerStart = true;
    public Text timerText;
    GameObject farmer = GameObject.Find("Farm");
    FarmerController s = farmer.GetComponent<FarmerController>();
    GameObject chicken = GameObject.Find("Chicken");
    ChickenController cs = chicken.GetComponent<ChickenController>();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerStart)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString();
        }

        
        //Check win
        if (s.getChickenHit())
        {

        }
    }

    //resets the game
    private void restartGame()
    {

    }
    //one object that slides up into the cameral view
    //change the sprite to match the winner
    private void winBanners(bool ChickenWin)
    {
        
    }

    //an overlay
    private void StartMenu()
    {

    }
}
