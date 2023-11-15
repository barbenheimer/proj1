using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flame : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    public GameObject leftmost;
    public GameObject rightmost;
    private Rigidbody2D rb;
    private Transform currentPoint;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.GetComponent<Player>())
        {
            SceneManager.LoadScene("gameover");
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = rightmost.transform;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == rightmost.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == rightmost.transform)
        {
            Flip();
            currentPoint = leftmost.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftmost.transform)
        {
            Flip();
            currentPoint = rightmost.transform;
        }
    }
}
