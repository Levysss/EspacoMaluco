using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textRecord;
    [SerializeField] private PlayerController player;

    private int pontosRecord = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        if (pontosRecord < player.getPontos())
        {
            pontosRecord = player.getPontos();
            textRecord.text = pontosRecord.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
