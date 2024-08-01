using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D myRb;
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRb.velocity = Vector2.up*speed;
    }
}
