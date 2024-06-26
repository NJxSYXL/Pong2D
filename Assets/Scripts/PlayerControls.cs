using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    private Vector2 OriginPos;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        OriginPos = transform.position;
    }
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }

    public void ResetPosition()
    {
        transform.position = OriginPos;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("Hit_SFX").GetComponent<AudioSource>().Play();
    }
}