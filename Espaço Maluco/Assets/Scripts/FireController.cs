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
        myRb.velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        alcance();
        
    }
    void alcance()
    {
        Vector3 posicao = transform.position;
        if(posicao.y > 7)
        {
            Destroy(eu);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(eu);
    }
}
