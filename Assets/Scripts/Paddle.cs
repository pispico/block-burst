using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{



    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 14.90f;
    [SerializeField] float screenWidthInUnits = 16f;

    void Start()
    {
        
    }

    void Update()
    {
        //16 is the number of units configured in the camera ans aspect ratio
        float mousePosInUnits =  Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePosInUnits, xMin, xMax);
        transform.position = paddlePosition;



    }
}
