using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //for jumping, need phyisics so will declare rigidbody
    Rigidbody2D rigidbody2D;
    //tracking ability to do double jump
    public int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        //set the rigidbody component to the one on the object as soon as the game starts
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //moving the player left and right

        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        transform.position = position;


        //jump stuff
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpsLeft > 0)
            {
                jumpsLeft--;
                rigidbody2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            }
        }

    }


}
