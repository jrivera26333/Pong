using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2Ai : MonoBehaviour
{
    public float movementSpeed;

    public GameObject ball;

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.y - ball.transform.position.y) > 50) //If the position of the ball is higher then where our current position is by more then 50 units
        {
            if (transform.position.y < ball.transform.position.y) //Please move our Racket up
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed; //Move our position up
            }
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed; //Move our position down
        }
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //Don't move if we are close enough
    }
}
