using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChickenController : MonoBehaviour
{

    public float speed = 0.1f;
    public float FarmWidth = 2;
    public float FarmHeight = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float DeltaX = Input.GetAxis("Horizontal") * speed;
        float DeltaY = Input.GetAxis("Vertical") * speed;
        float InitX = transform.position.x;
        float InitY = transform.position.y;
        float NextPosX = InitX + DeltaX;
        float NextPosY = InitY + DeltaY;
        if (Math.Abs(NextPosX) >= FarmWidth)
        {
            DeltaX = 0;
            if (NextPosX > 0)
            {
                transform.position = new Vector3(FarmWidth, transform.position.y, 0);
            }
            else
            {
                transform.position = new Vector3(-FarmWidth, transform.position.y, 0);
            }
        }
        if (Math.Abs(NextPosY) >= FarmHeight)
        {
            DeltaY = 0;
            if (NextPosY > 0)
            {
                transform.position = new Vector3(transform.position.x, FarmHeight, 0);
            }
            else
            { 
                transform.position = new Vector3(transform.position.x, -FarmHeight, 0);
            }
        }

        Vector3 movement = new Vector3(DeltaX, DeltaY, 0f);
        transform.position += movement;

    }
}
