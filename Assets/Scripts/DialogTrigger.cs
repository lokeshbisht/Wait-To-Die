using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    [TextArea(3, 10)]
    public string sentence;
    public GameObject nextDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogManager>().StartDialog(sentence);
            Instantiate(nextDialog);
            Destroy(this.gameObject);
        }
    }
}
