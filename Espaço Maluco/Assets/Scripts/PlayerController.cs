using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Vector3 minhaPosicao;
    private Rigidbody2D meuRb;
    
    // Start is called before the first frame update
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        minhaPosicao = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }
    //metodo para movimentacao do nosso player
    void Movimentacao()
    {

     
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            minhaPosicao.y = minhaPosicao.y + Time.deltaTime * speed;
            meuRb.velocity = minhaPosicao;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            minhaPosicao.y = minhaPosicao.y + Time.deltaTime * -speed;
            meuRb.velocity = minhaPosicao;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            minhaPosicao.x = minhaPosicao.x + Time.deltaTime * -speed;
            meuRb.velocity = minhaPosicao;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            minhaPosicao.x = minhaPosicao.x + Time.deltaTime * speed;
            meuRb.velocity = minhaPosicao;  
        }
        
        
        
    }

    
}
