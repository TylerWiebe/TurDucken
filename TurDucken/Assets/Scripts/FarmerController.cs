using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    public float BlastRadius = 0.25f;
    public float Delay = 0f;
    private bool hasHitChicken = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 crosshairPos = new Vector3(mousePosition.x, mousePosition.y, 0);
        transform.position = crosshairPos;
        if (Input.GetMouseButtonDown(0))
        {
            DelayFunction();
            GameObject chicken = GameObject.Find("Chicken");
            Vector3 chickenPos = chicken.transform.position;
            float DistBetween = Mathf.Sqrt((Mathf.Pow(Mathf.Abs(chickenPos.x - crosshairPos.x), 2) + Mathf.Pow(Mathf.Abs(chickenPos.y - crosshairPos.y), 2)));
            Debug.Log(DistBetween);
            if (DistBetween <= BlastRadius)
            {
                hasHitChicken = true;
                Debug.Log("This is a test");
            }
        }
    }
    
    IEnumerator DelayFunction()
    {
        yield return new WaitForSeconds(Delay * 0.5f);
    }

    public bool getChickenHit()
    {
        return hasHitChicken;
    }
}
