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
                
               
                anim.SetBool("IsJumping", true);

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            anim.SetBool("IsJumping", false);
            jumpsLeft = 2;
        }
    }
}
