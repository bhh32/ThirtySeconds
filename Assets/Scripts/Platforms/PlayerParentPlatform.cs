/** Written By Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentPlatform : MonoBehaviour 
{
    void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Player"))
            other.transform.parent = transform;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Player"))
            other.transform.parent = null;
    }
}
