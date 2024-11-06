using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGraundController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    private Renderer fundo;
    private float yOffset;
    private Vector2 posicaoTextura;

    void Start()
    {
        fundo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        yOffset += Time.deltaTime*speed;
        posicaoTextura.y = yOffset;

        fundo.material.mainTextureOffset = posicaoTextura;

        
    }
}
