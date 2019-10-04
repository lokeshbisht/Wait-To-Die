using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger2 : MonoBehaviour {

    [TextArea(3, 10)]
    public string dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
            Destroy(this.gameObject);
        }
    }
}
