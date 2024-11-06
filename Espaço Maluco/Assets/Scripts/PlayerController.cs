using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject bala;
    [SerializeField] private int vida = 100;

    //Variaveis de Pontos e de Vida em texto
    [SerializeField] private TextMeshProUGUI vidaText;
    [SerializeField] private TextMeshProUGUI pontosText;
    [SerializeField] private TextMeshProUGUI record;

    [SerializeField] private AudioClip tiroSom;

    private int pontos;
    private Animator[] animacao;
    private float deley = 0.01f;
    private Rigidbody2D meuRb;
    private Vector3 armaPosicao;
    private int scoreMaximoo;
    private string nomeCena;

    // Start is called before the first frame update
    void Start()
    {
        
        meuRb = GetComponent<Rigidbody2D>();
        animacao = GetComponentsInChildren<Animator>();
        nomeCena = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey(nomeCena + "score"))
        {
            scoreMaximoo = PlayerPrefs.GetInt(nomeCena + "score");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteKey(nomeCena + "score");
            SceneManager.LoadScene("Game");
        }
        atualizarInterface();
        TomeBala();
    }
    private void FixedUpdate()
    {
        Movimentacao();
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
            //AudioSource.PlayClipAtPoint(tiroSom,armaPosicao);
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
            vida -= 10;
        }
        
        if(vida <= 0)
        {
            scoreMaximo();
            SceneManager.LoadScene("Game");
        }
    }

    public void pegarPontos(int pontos)
    {
        this.pontos += pontos;
    }

    void atualizarInterface()
    {
        vidaText.text = "Vida: " + vida.ToString();
        pontosText.text ="Pontos: " + pontos.ToString();
        record.text = "Record: " + scoreMaximoo.ToString();
    }
    void scoreMaximo()
    {
        
        if (pontos > scoreMaximoo)
        {
            scoreMaximoo = pontos;
            PlayerPrefs.SetInt(nomeCena+"score",scoreMaximoo);
            record.text = "Record: " + scoreMaximoo.ToString();
        }
    }
    
}
