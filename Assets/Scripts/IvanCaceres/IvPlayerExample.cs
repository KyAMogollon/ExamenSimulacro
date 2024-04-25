using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvPlayerExample : BasePlayerController, IvIAimable, IvIMoveable, IvIAttackable
{
    public GameObject prefabExplotion;
    public float playerVelocity = 4f;
    Vector2 pos;
    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        OnMovement();
    }
    public void Move(Vector2 direction)
    {
        pos = direction;
    }

    public void Attack(Vector2 position)
    {
        Vector3 local = CalculatePos(position);
        Instantiate(prefabExplotion, new Vector3(local.x, local.y + 1, local.z), Quaternion.identity);
    }
    private void OnMovement()
    {
        myRigidBody.transform.position = new Vector3(transform.position.x + pos.x * playerVelocity * Time.deltaTime, transform.position.y + pos.y * playerVelocity * Time.deltaTime, transform.position.z);
    }
    private Vector3 CalculatePos(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = hit.point;
            return hitPoint;
        }

        return Vector3.zero;
    }
}
