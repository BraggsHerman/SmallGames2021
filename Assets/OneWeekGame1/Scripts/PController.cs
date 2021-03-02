using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    Rigidbody2D rb;
    public int jumpsLeft;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;



        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        transform.position = position;
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        

        //jump stuff
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsLeft > 0)
            {
                jumpsLeft--;
                rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
                
            }
            if (jumpsLeft <= 0)
            {
                Invoke("JumpReset", 0.75f);
            }
        }
    }

    public void JumpReset()
    {
        jumpsLeft += 2;
    }
}

