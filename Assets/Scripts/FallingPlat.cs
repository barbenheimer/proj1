using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.6f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 5f);
    }
}
