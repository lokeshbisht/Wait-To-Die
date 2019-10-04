using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger3 : MonoBehaviour {

    [TextArea(3, 10)]
    public string sentence;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogManager>().StartDialog(sentence);
            Destroy(this.gameObject);
        }
    }
}
