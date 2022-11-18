using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    float velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DoMove());
    }

    IEnumerator DoMove()
    {
        for (int i = 0; i < 5; i++)
        {
            velocity = 1f;
            yield return new WaitForSeconds(2.5f);
            velocity = -5f;
            yield return new WaitForSeconds(0.5f);
        }
        velocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb.velocity;
        vel.x = -velocity;
        rb.velocity = vel;
    }
}
