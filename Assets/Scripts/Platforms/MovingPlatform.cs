/** Rewritten by Bryan Hyland
    Previous version written by 
    Evan
    *Note: Rewritten because logic didn't work in
           all situations.
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Set Direction")]
    [SerializeField] bool isVertical;
    [SerializeField] bool isHorizontal;

    [Header("Set Speed")]
    [Tooltip("Positive to Right, Negative to Left")]
    [SerializeField] float horizontalSpeed;
    [Tooltip("Positive to Up, Negative to Down")]
    [SerializeField] float verticalSpeed;

    [Header("Set Endpoints")]
    [SerializeField] Transform[] points;

    void Update()
    {
        if (isVertical && !isHorizontal)
            MoveVertical();

        if (isHorizontal && !isVertical)
            MoveHorizontal();

        if (isHorizontal && isVertical)
            MoveDiagonal();

    }

    void MoveVertical()
    {
        if (points[0].transform.localPosition.y < points[1].transform.localPosition.y)
        {
            if (transform.localPosition.y >= points[1].transform.localPosition.y ||
                transform.localPosition.y <= points[0].transform.localPosition.y)
            {
                verticalSpeed *= -1;
            }
        }
        else if (points[1].transform.localPosition.y < points[0].transform.localPosition.y)
        {
            if (transform.localPosition.y >= points[0].transform.localPosition.y ||
               transform.localPosition.y <= points[1].transform.localPosition.y)
            {
                verticalSpeed *= -1;
            }
        }

        transform.Translate(0f, verticalSpeed * Time.deltaTime, 0f);
    }

    void MoveHorizontal()
    {
        if (points[0].transform.position.x < points[1].transform.position.x)
        {
            if (transform.position.x <= points[0].transform.position.x ||
                transform.position.x >= points[1].transform.position.x)
            {
                horizontalSpeed *= -1;
            }
        }
        else if (points[0].transform.position.x > points[1].transform.position.x)
        {
            if (transform.position.x <= points[1].transform.position.x ||
                transform.position.x >= points[0].transform.position.x)
            {
                horizontalSpeed *= -1;
            }
        }

        transform.Translate(horizontalSpeed * Time.deltaTime, 0f, 0f);
    }

    void MoveDiagonal()
    {
        if (points[1].transform.position.x < points[0].transform.position.x &&
            points[1].transform.position.y < points[0].transform.position.y)
        {
            if (transform.position.x <= points[1].transform.position.x &&
                transform.position.y <= points[1].transform.position.y ||
                transform.position.x >= points[0].transform.position.x &&
                transform.position.y >= points[0].transform.position.y)
            {
                horizontalSpeed *= -1f;
                verticalSpeed *= -1f;
            }
        }
        else if (points[1].transform.position.x > points[0].transform.position.x &&
                 points[1].transform.position.y > points[0].transform.position.y)
        {
            if (transform.position.x >= points[1].transform.position.x &&
                transform.position.y >= points[1].transform.position.y ||
                transform.position.x <= points[0].transform.position.x &&
                transform.position.y <= points[0].transform.position.y)
            {
                horizontalSpeed *= -1f;
                verticalSpeed *= -1f;
            }
        }
        else if (points[1].transform.position.x < points[0].transform.position.x &&
                 points[1].transform.position.y > points[0].transform.position.y)
        {
            if (transform.position.x <= points[1].transform.position.x &&
                transform.position.y >= points[1].transform.position.y ||
                transform.position.x >= points[0].transform.position.x &&
                transform.position.y <= points[0].transform.position.y)
            {
                horizontalSpeed *= -1f;
                verticalSpeed *= -1f;
            }
        }
        else if (points[1].transform.position.x > points[0].transform.position.x &&
                 points[1].transform.position.y < points[0].transform.position.y)
        {
            if (transform.position.x >= points[1].transform.position.x &&
                transform.position.y <= points[1].transform.position.y ||
                transform.position.x <= points[0].transform.position.x &&
                transform.position.y >= points[0].transform.position.y)
            {
                horizontalSpeed *= -1f;
                verticalSpeed *= -1f;
            }
        }

        transform.Translate(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0f);
    }
}