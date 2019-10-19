using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentOffscreen : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
