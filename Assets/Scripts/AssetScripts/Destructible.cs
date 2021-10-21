using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    Vector2 forceDirection;

    [SerializeField]
    float torque;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        float randTorque = UnityEngine.Random.Range(-200, 200);
        float randForceX = UnityEngine.Random.Range(forceDirection.x - 50, forceDirection.x + 50);
        float randForceY = UnityEngine.Random.Range(forceDirection.y, forceDirection.y + 50);

        forceDirection.x = randForceX;
        forceDirection.y = randForceY;

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDirection);
        rb2d.AddTorque(randTorque);
    }


}
