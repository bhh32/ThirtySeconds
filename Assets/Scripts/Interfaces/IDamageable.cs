/** Written By Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
    void GiveDamage(GameObject thisObj, float damage);
}
