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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerStart)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString();
        }

        GameObject farmer = GameObject.Find("Farm");
        FarmerController s = farmer.GetComponent<FarmerController>();
        GameObject chicken = GameObject.Find("Chicken");
        ChickenController cs = chicken.GetComponent<ChickenController>();
        
        if (s.getChickenHit())
        {

        }
    }
}
