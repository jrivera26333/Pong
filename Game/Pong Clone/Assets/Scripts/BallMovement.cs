using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBall()); //To call a Coroutine you must use this function and then as the parameter add the IEnumerator function
    }

    void PositionBall(bool isStartingPlayer1)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //We want the velocity to be at 0,0

        if(isStartingPlayer1)
        {
            gameObject.transform.localPosition = new Vector3(-100, 0, 13); //The ball will be on the left side of the screen
        }else
            gameObject.transform.localPosition = new Vector3(100, 0, 13); //The ball will be on the left side of the screen
    }

    //A coroutine is like a function that has the ability to pause execution and return control to Unity but then to continue where it left off on the following frame
    public IEnumerator StartBall(bool isStartingPlayer1 = true) //Whenever start ball is called we wait two seconds and then we start movement
    {
        PositionBall(isStartingPlayer1); //Place the ball on this side

        hitCounter = 0;

        yield return new WaitForSeconds(2); //Adding a delay to the function call

        if (isStartingPlayer1)
            MoveBall(new Vector2(-1, 0)); //Move ball to the left
        else
            MoveBall(new Vector2(1, 0));
    }

    //Coroutine it forces everything to wait for it before new actions happen

    public void MoveBall(Vector2 dir) //Either move it to the left of the right at start
    {
        dir = dir.normalized;

        float speed = movementSpeed + hitCounter * extraSpeedPerHit;

        Rigidbody2D rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = dir * speed; //Velocity is the speed of an object at a given direction
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeedPerHit <= maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
