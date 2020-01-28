using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    public float playerMovementSpeed = 200;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical2");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * playerMovementSpeed; //By altering the Rigidbody we are able to move it up and down. We got the Rigidbody and we are changing the Vector2D(0,v) v is our variable that we get from our vertical movement. Then we simply multiply it by our movement speed.
    }
}
