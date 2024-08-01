using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject bala;
    
    private Rigidbody2D meuRb;
    private Vector3 armaPosicao;
    // Start is called before the first frame update
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        
        
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            armaPosicao = transform.position + Vector3.up * 0.5f;
            Instantiate(bala,armaPosicao,Quaternion.identity);
        }
    }
    
}
