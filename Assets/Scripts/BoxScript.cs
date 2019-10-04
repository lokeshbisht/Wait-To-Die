using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

    public float rate;

    public GameObject firstSwitch;
    public GameObject secondSwitch;
    public GameObject thirdSwitch;

    public GameObject dialog;

    public GameObject check;

    [TextArea(3, 10)]
    public string dialogText;

    private bool shrink;
    public bool gameOn;
    private bool first = true;
    private Transform boxTransform;

    // Use this for initialization
    void Start()
    {
        shrink = true;
        gameOn = true;

        boxTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (firstSwitch.GetComponent<SpriteRenderer>().color == Color.red
           && secondSwitch.GetComponent<SpriteRenderer>().color == Color.blue
           && thirdSwitch.GetComponent<SpriteRenderer>().color == Color.red)
        {
            shrink = false;

            if (first)
            {
                DestroyCheck();
                FindObjectOfType<DialogManager>().StartDialog(dialogText);
                first = false;
                Instantiate(dialog);
            }
            
        }
        else
        {
            shrink = true;
        }

        if (shrink && gameOn)
        {
            Shrink();
        }
    }

    private void Shrink()
    {
        float scaleVal = boxTransform.localScale.x - rate;
        boxTransform.localScale = new Vector3(scaleVal, boxTransform.localScale.y, boxTransform.localScale.z);
    }

    public void DestroyCheck()
    {
        Destroy(check);
    }
}
