using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeRotation : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed, 0, 0);
    }
}
