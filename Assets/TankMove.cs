using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // Start is called before the first frame update
    float velocity;
    float angularVelocity;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(DoMove());
    }

    public IEnumerator DoMove()
    {
        for (int i = 0; i < 75; i++)
        {
            velocity = 5;
            yield return new WaitForSeconds(Random.Range(0.5f, 5f));
            velocity = 0;
            var backwardMultiplier = Random.Range(0, 2) == 1 ? 1 : -1;
            angularVelocity = 3.1415926536f * 2 / 5 * backwardMultiplier;
            yield return new WaitForSeconds(Random.Range(0.1f, 2.5f));
            angularVelocity = 0;
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            return;
        }
        rb.velocity = Vector3.Scale(rb.velocity, new Vector3(0, 1, 0)) + (transform.rotation * Vector3.forward * velocity);
        rb.angularVelocity = new Vector3(0, angularVelocity, 0);
    }
}
