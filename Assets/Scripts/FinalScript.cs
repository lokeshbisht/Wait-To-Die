using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour {

    public GameObject finalMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Stop("Theme");
            Time.timeScale = 0f;
            finalMessage.SetActive(true);
        }
    }
}
