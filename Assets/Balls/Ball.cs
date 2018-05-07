using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float fallingSpeed = 0.1f;
    private Rigidbody ball;

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        InvokeRepeating("Drop", 0f, Time.deltaTime);
    }
    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = collision.transform.position - transform.position;
        if (Vector3.Dot(Vector3.down, direction) > 0)
        {
            print("Down");
            CancelInvoke();
        }
        if (Vector3.Dot(Vector3.down, direction) < 0)
        {
            print("Up");
        }
        if (Vector3.Dot(Vector3.down, direction) == 0)
        {
            print("Side");
        }
        print(collision.gameObject.name);
    }

    private void Drop()
    {
        transform.Translate(Vector3.down * fallingSpeed);
        print("falling...");
    }
}
