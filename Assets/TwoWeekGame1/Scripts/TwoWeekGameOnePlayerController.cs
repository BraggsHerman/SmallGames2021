using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWeekGameOnePlayerController : MonoBehaviour
{
    public int jumpsLeft;
    Rigidbody2D rb;
    public int speed;
    public Animator anim;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horitzontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + speed * horitzontal * Time.deltaTime;
        transform.position = position;
        Debug.Log(horitzontal);
        
        anim.SetFloat("Speed", Mathf.Abs(horitzontal));

        if(horitzontal < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsLeft > 0)
            {
                jumpsLeft--;
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
                
                //for jumping, if time permits, come back and set  up layermasks so that jumping animation works
                //anim.SetBool("IsJumping", true);

            }
            if (jumpsLeft <= 0)
            {
                Invoke("JumpReset", 0.5f);
            }
        }
    }

    public void JumpReset()
    {
        jumpsLeft += 2;
    }
}
