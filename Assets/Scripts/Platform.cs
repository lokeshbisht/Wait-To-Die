using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public GameObject leftYellow;
    public GameObject rightYellow;
    public GameObject leftRed;
    public GameObject rightRed;

    public Transform box;

    private Vector3 leftY;
    private Vector3 leftR;
    private Vector3 rightY;
    private Vector3 rightR;

    public float smoothSpeed;

    private bool lY;
    private bool lR;
    private bool rY;
    private bool rR;

    // Use this for initialization
    void Start () {

        lY = true;
        lR = true;
        rY = true;
        rR = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (lY)
        {
            if (box.GetComponent<Transform>().localScale.x < 4.12f)
            {
                leftY = Vector3.Lerp(leftYellow.GetComponent<Transform>().position,
                new Vector3(leftYellow.GetComponent<Transform>().position.x, -12f, leftYellow.GetComponent<Transform>().position.z),
                smoothSpeed);
                Debug.Log("here");
                leftYellow.GetComponent<Transform>().position = leftY;
            }

            if (leftYellow.GetComponent<Transform>().position.y <= -11f)
            {
                lY = false;
                Destroy(leftYellow);
            }
        }

        if (rY)
        {
            if (box.GetComponent<Transform>().localScale.x < 4.12f)
            {
                rightY = Vector3.Lerp(rightYellow.GetComponent<Transform>().position,
                new Vector3(rightYellow.GetComponent<Transform>().position.x, -12f, rightYellow.GetComponent<Transform>().position.z),
                smoothSpeed);
                rightYellow.GetComponent<Transform>().position = rightY;
            }

            if (rightYellow.GetComponent<Transform>().position.y <= -11f)
            {
                rY = false;
                Destroy(rightYellow);
            }
        }

        if (lR)
        {
            if (box.GetComponent<Transform>().localScale.x < 1.6f)
            {
                leftR = Vector3.Lerp(leftRed.GetComponent<Transform>().position,
                new Vector3(leftRed.GetComponent<Transform>().position.x, -12f, leftRed.GetComponent<Transform>().position.z),
                smoothSpeed);
                leftRed.GetComponent<Transform>().position = leftR;
            }

            if (leftRed.GetComponent<Transform>().position.y <= -11f)
            {
                lR = false;
                Destroy(leftRed);
            }
        }

        if (rR)
        {
            if (box.GetComponent<Transform>().localScale.x < 1.6f)
            {
                rightR = Vector3.Lerp(rightRed.GetComponent<Transform>().position,
                new Vector3(rightRed.GetComponent<Transform>().position.x, -12f, rightRed.GetComponent<Transform>().position.z),
                smoothSpeed);
                rightRed.GetComponent<Transform>().position = rightR;
            }

            if (rightRed.GetComponent<Transform>().position.y <= -11f)
            {
                rR = false;
                Destroy(rightRed);
            }
        }

    }
}
