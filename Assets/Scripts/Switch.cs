using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int rand = Random.Range(1, 3);

        if (rand == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (rand == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    public void ChangeColor()
    {
        if (GetComponent<SpriteRenderer>().color == Color.blue)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            return;
        } else if (GetComponent<SpriteRenderer>().color == Color.red)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        } else if (GetComponent<SpriteRenderer>().color == Color.yellow)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }


    }
}
