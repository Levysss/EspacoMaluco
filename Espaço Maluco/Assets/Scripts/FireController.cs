using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject eu;
    [SerializeField] private GameObject portador;
    [SerializeField] private GameObject inpacto;
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
        
            //guardando a direcao de onde esta o player
            Vector2 direction = alvo.transform.position - transform.position;

            transform.rotation = Quaternion.LookRotation(direction);
            */
            Vector2 direction = new Vector2(alvo.transform.position.x - transform.position.x  , alvo.transform.position.y - transform.position.y);

            transform.up = direction;
            direction = direction.normalized;
            myRb.velocity = direction * speed;
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
        

        //se a bala n tiver visivel apaque!!!
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        if (visivel == false)
        {
            Destroy(gameObject);
        }
        
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Instantiate(inpacto,transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
