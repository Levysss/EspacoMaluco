using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField] private GameObject alvo;
    [SerializeField] private float speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        Visao();
    }
    void Movimentacao()
    {
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
        Vector2 direction = new Vector2(transform.position.x- alvo.transform.position.x,  transform.position.y - alvo.transform.position.y );

        transform.up = direction;
    }
}
