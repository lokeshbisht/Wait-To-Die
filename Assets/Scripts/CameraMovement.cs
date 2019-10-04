using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private bool move;
    // Use this for initialization
    void Start()
    {
        move = false;
        offset = new Vector3(5, 0, -10);
    }

    private void FixedUpdate()
    {
        if (move)
        {

            Vector3 nextPos = target.position + offset;

            if (nextPos.y < -20.5f)
            {
                nextPos.y = -20.5f;
            }
            if (nextPos.x < -150f)
            {
                nextPos.x = -150f;
            }

            if (nextPos.x > 800f)
            {
                nextPos.x = 800f;
            }

            Vector3 newPos = Vector3.Lerp(transform.position, nextPos, smoothSpeed);
            transform.position = newPos;
        }
    }

    public void StartMovement ()
    {
        move = true;
    }
}
