using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public TextMeshProUGUI WinnerText;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WinnerText.text = "You win!!!";
            Destroy(other.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
