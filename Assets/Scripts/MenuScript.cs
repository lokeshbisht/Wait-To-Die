using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
