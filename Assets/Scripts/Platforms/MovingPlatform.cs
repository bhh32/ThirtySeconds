using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isVertical;
    public float moveSpeed;
    public Transform[] points;

    private void Update()
    {
        if (isVertical == true)
        {
            if (transform.localPosition.y >= points[0].transform.localPosition.y
                ||
                transform.localPosition.y <= points[1].transform.localPosition.y)
            {
                moveSpeed *= -1;
            }

            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            if (transform.localPosition.x >= points[0].transform.localPosition.x
                ||
                transform.localPosition.x <= points[1].transform.localPosition.x)
            {
                moveSpeed *= -1;
            }

            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }


    }
}
