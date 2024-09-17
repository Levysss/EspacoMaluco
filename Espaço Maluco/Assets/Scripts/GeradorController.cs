using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorController : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigo1;
    [SerializeField] private float tempoParaIniciar = 3f;
    [SerializeField] private float tempoSpaw = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gerar();
    }
    void gerar()
    {
        
        float chances = Random.Range(0, 1f);
        Vector3 rangeSpaw = new Vector3(Random.Range(-20,20),10,0);
        transform.position = rangeSpaw;
        tempoParaIniciar = tempoParaIniciar - Time.deltaTime;
        if (tempoParaIniciar <= 0)
        {
            
            //gerar o zoiudo com mais chance de "70"
            if (chances <= 0.7f)
            {
                Instantiate(inimigo1[0],transform.position,Quaternion.identity);
            }
            if (chances >0.7f)
            {
                Instantiate(inimigo1[1],transform.position, Quaternion.identity);
            }
            tempoParaIniciar = tempoSpaw;
        }
    }
}
