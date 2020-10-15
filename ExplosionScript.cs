using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    // Add to explosion animation prefab.
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }

}
