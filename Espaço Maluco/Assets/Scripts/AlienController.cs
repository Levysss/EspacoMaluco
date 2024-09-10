using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField] private GameObject eu;
    [SerializeField] private PlayerController alvo;
    [SerializeField] private float speed = 8;
    [SerializeField] private int vida = 100;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject meuTiro;
    public float deley = 1f;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        
        alvo = FindAnyObjectByType<PlayerController>();
        deley = Random.Range(0.5f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        Atirador();
    }
    //movimentação
    void Movimentacao()
    {
        Visao();
        //verificando se estou encostando no player
        if (transform.position != alvo.transform.position)
        {
            //se verdadeiro segnifica q nao estamos mili
            if (alvo.transform.position.x < transform.position.x)
            {
                transform.position -= Vector3.right * Time.deltaTime * speed;
            }
            if (alvo.transform.position.x > transform.position.x)
            {
                transform.position -= Vector3.left * Time.deltaTime * speed;
            }
            if (alvo.transform.position.y < transform.position.y)
            {
                transform.position -= Vector3.up * Time.deltaTime * speed;
            }
            if (alvo.transform.position.y > transform.position.y)
            {
                transform.position -= Vector3.down * Time.deltaTime * speed;
            }
        }
        
    }
    void Visao()
    {
        //movimentacao da visao
        Vector2 direction = new Vector2(transform.position.x - alvo.transform.position.x, transform.position.y - alvo.transform.position.y);

        transform.up = direction;
    }
    
    //Parte do dano  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            //Aplicando dono ao inimigo
            RecebaDano(25);
            //Carregar animação de dano
            if(eu.CompareTag("Bejoqueiro")) {
                transform.position -= Vector3.down * 3.5f;
            }
            
            this.animator.SetTrigger("recebendoDano");
        }
    }
    void RecebaDano(int dano)
    {
        vida -= dano;
        if(vida < 0)
        {
            Morra();
        }
    }
    void Morra()
    {
        Destroy(eu);
    }
    void Atirador()
    {
        if (checarVisibilidade())
        {
            if (eu.CompareTag("Zoiudo"))
            {
                Vector3 armaPosicao = transform.position + Vector3.down * 1f;
                deley = deley - Time.deltaTime;
                if (deley <= 0)
                {
                    Instantiate(meuTiro, armaPosicao, Quaternion.identity);
                    deley = 1f;
                }

            }
        }
        
    }

    bool checarVisibilidade()
    {
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;
        return visivel;
    }

}

