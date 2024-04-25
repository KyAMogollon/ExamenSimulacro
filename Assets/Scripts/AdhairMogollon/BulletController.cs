using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody _rb;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void positiobullet(Vector3 position)
    {
        Vector3 direction = new Vector3(position.x, 0, 0).normalized;
        _rb.velocity = direction* speed;
    }
}
