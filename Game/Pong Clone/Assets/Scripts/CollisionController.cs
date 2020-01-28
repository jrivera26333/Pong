using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement; //We created an object of BallMovement and increment one of its methods. We drag the instance of the ball movement here
    public ScoreController scoreController; //We got an instance of the score controller because this is where we increment our points

    void BounceFromRacket(Collision2D c)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y; //Returns the height of the bounds of our racket.

        float x;
        if(c.gameObject.name == "Player 1")
        {
            x = 1; //Towards the right
        }
        else
        {
            x = -1; //Torwards the left
        }

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter(); //We increase our hit counter so the speed of our ball is increased
        ballMovement.MoveBall(new Vector2(x, y)); //We are adding in the new direction the ball should be going towards. Plus we increase the counter before calling this
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "WallLeft")
        {
            scoreController.GoalPlayer2();
            Debug.Log("Collision with wall left");
            StartCoroutine(ballMovement.StartBall(true)); //Move the ball to the left side but use the Coroutine to give a pause then move it
        }
        else if(collision.gameObject.name == "WallRight")
        {
            scoreController.GoalPlayer1();
            Debug.Log("Collision with wall right");
            StartCoroutine(ballMovement.StartBall(false)); //Move the ball to the left side but use the Coroutine to give a pause then move it
        }
    }
}
