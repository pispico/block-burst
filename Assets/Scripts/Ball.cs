using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //states
    Vector2 paddleToBallVector;
    Boolean hasStarted = false;

    //Caches references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;



    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hasStarted == false)
        {
            LockBallInPaddle();
            LauchOnMouseClick();
        }
    }

    private void LauchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2d.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallInPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2 (Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2d.velocity += velocityTweak;
        }
    }
}
