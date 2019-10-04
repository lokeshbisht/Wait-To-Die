using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {

    public TextMeshProUGUI displayText;
    public float typingSpeed;

    public float displayTime;
    private float curTime;

    public Animator animator;

    private bool typing;

    public GameObject dialogBox;

    public void Start()
    {
        typing = false;
        curTime = 0;
    }

    public void Update()
    {

        if (typing)
        {
            curTime += Time.deltaTime;

            if (curTime >= displayTime)
            {
                curTime = 0;
                EndDialog();
            }
        }
    }
    public void StartDialog(string dialog)
    {
        dialogBox.SetActive(true);
        animator.SetBool("IsOpen", true);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialog));

        typing = true;
    }
    IEnumerator TypeSentence(string sentence)
    {
        displayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialog()
    {
        typing = false;
        animator.SetBool("IsOpen", false);
        dialogBox.SetActive(false);
    }
}
