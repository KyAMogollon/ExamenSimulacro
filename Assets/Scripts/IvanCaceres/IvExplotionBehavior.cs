using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvExplotionBehavior : MonoBehaviour
{
    public float timeForDestruction = 2f;
    private void Start()
    {
        Destroy(this.gameObject, timeForDestruction);
    }
}
