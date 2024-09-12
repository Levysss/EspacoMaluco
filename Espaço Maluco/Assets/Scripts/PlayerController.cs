using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject bala;
    [SerializeField] private int vida = 5;
    

    private Animator[] animacao;
    private float deley = 0.2f;
    private Rigidbody2D meuRb;
    private Vector3 armaPosicao;

    // Start is called before the first frame update
    void Start()
    {
        
        meuRb = GetComponent<Rigidbody2D>();
        animacao = GetComponentsInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        TomeBala();
    }
    //metodo para movimentacao do nosso player diferenciado
    
    void Movimentacao()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 minhaMovimentacao = new Vector2(horizontal, vertical);
        minhaMovimentacao.Normalize();
        meuRb.velocity = minhaMovimentacao*speed;
    }
    void TomeBala()
    {
        

        if (Input.GetButton("Fire1"))
        {
            deley = deley - Time.deltaTime;
            if (deley <= 0)
            {
                armaPosicao = transform.position + Vector3.up * 0.5f;
                Instantiate(bala, armaPosicao, Quaternion.identity);
                deley = 0.2f;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bejoqueiro") || collision.gameObject.CompareTag("Parede")) {
            vida = vida;

        }
        else
        {
            this.animacao[0].SetTrigger("RecebendoDano");
            vida--;
        }
        
        if(vida <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

}
