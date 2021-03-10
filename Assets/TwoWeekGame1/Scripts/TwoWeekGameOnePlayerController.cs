using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWeekGameOnePlayerController : MonoBehaviour
{
    public int jumpsLeft;
    Rigidbody2D rb;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horitzontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + speed * horitzontal * Time.deltaTime;
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsLeft > 0)
            {
                jumpsLeft--;
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
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
