using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject eu;
    private Rigidbody2D myRb;
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        alcance();
        myRb.velocity = Vector2.up*speed;
    }
    void alcance()
    {
        Vector3 posicao = transform.position;
        if(posicao.y > 7)
        {
            Destroy(eu);
        }
    }
}
