using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject eu;
    [SerializeField] private GameObject portador;
    [SerializeField] private PlayerController alvo;
    private Rigidbody2D myRb;
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        if (portador.CompareTag("Player"))
        {
            myRb.velocity = Vector2.up * speed;
        }
        if (portador.CompareTag("Zoiudo"))
        {
            alvo = FindObjectOfType<PlayerController>();
            /*
            Vector2 direction = new Vector2(transform.position.x - alvo.transform.position.x, transform.position.y - alvo.transform.position.y);

            transform.up = direction;

            myRb.velocity = new Vector2(alvo.transform.position.x - transform.position.x, alvo.transform.position.y - transform.position.y );
        */
            //guardando a direcao de onde esta o player
            Vector2 direction = alvo.transform.position - transform.position;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    private void FixedUpdate()
    {
        if (portador.CompareTag("Zoiudo"))
        {
            
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (eu.CompareTag("Player"))
        {
            alcance();
        }
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
