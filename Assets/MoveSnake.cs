using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;

public class MoveSnake : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && rb.rotation != 0)
        {
            rb.velocity = Vector2.up * speed;
            transform.DORotate(new Vector3(0, 0, 180), 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && rb.rotation != -180)
        {
            rb.velocity = Vector2.down * speed;
            transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && rb.rotation != 90)
        {
            rb.velocity = Vector2.left * speed;
            transform.DORotate(new Vector3(0, 0, -90), 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.D) && rb.rotation != -90)
        {
            rb.velocity = Vector2.right * speed;
            transform.DORotate(new Vector3(0, 0, 90), 0.1f);

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Wall>() != null)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
