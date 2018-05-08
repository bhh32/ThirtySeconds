using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isVertical;
    public bool isHorizontal;
    public float moveSpeed;
    public Transform[] points;

    void MoveVertical()
    {
        if (points[0].transform.localPosition.y < points[1].transform.localPosition.y)
        {
            if (transform.localPosition.y <= points[0].transform.localPosition.y
                ||
                transform.localPosition.y >= points[1].transform.localPosition.y)
            {
                moveSpeed *= -1;
            }
        }
        else if (points[0].transform.localPosition.y > points[1].transform.localPosition.y)
        {
            if (transform.localPosition.y <= points[1].transform.localPosition.y
                ||
                transform.localPosition.y >= points[0].transform.localPosition.y)
            {
                moveSpeed *= -1;
            }
        }
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
    }

    void MoveHorizontal()
    {
        if (points[0].transform.localPosition.x < points[1].transform.localPosition.x)
        {
            if (transform.localPosition.x <= points[0].transform.localPosition.x
                ||
                transform.localPosition.x >= points[1].transform.localPosition.x)
            {
                moveSpeed *= -1;
            }
        }
        else if (points[0].transform.localPosition.x > points[1].transform.localPosition.x)
        {
            if (transform.localPosition.x <= points[1].transform.localPosition.x
                ||
                transform.localPosition.x >= points[0].transform.localPosition.x)
            {
                moveSpeed *= -1;
            }
        }
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    void MoveDiagonal()
    {
        MoveHorizontal();
        MoveVertical();
    }

    private void Update()
    {
        if (isVertical == true
            &&
            isHorizontal == false)
        {
            MoveVertical();
        }
        else if (isHorizontal == true
                &&
                isVertical == false)
        {
            MoveHorizontal();
        }
        else if (isHorizontal == true
                &&
                isVertical == true)
        {
            MoveDiagonal();
        }

    }
}
