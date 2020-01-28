using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    public float movementSpeed = 200;

    private void FixedUpdate() //We want movement to be precise since we are dealing with physics
    {
        float v = Input.GetAxisRaw("Vertical"); //We only want 1 or -1 nothing in between so we dont take smoothing in consideration

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed; //By altering the Rigidbody we are able to move it up and down. We got the Rigidbody and we are changing the Vector2D(0,v) v is our variable that we get from our vertical movement. Then we simply multiply it by our movement speed.
    }
}
