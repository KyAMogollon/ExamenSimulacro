using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APlayerExample : ABasePlayerController, AIAimable, AIMoveable, AIAttackable
{
    private Vector3 movementPlayer;
    public float speed;
    [SerializeField] GameObject bullet;

    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;

            Debug.Log("Aim from " + this.name);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Debug.Log("Child Awake");
    }

    protected override void Start()
    {
        base.Start();

        Debug.Log("Child Start");
    }
    public void FixedUpdate()
    {
        myRigidBody.velocity = new Vector3(movementPlayer.x*speed, myRigidBody.velocity.y, movementPlayer.z*speed);
    }
    public void Move(Vector2 direction)
    {
        movementPlayer = new Vector3(direction.x, 0, direction.y);
    }

    public void Attack(Vector2 position)
    {
        Debug.Log("Attack from " + this.name);
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(position.x,0, 0));
        if (Physics.Raycast(ray, out RaycastHit info))
        {
            Debug.Log("Disparo");
            Vector3 instantiatePoint = new Vector3(info.point.x, 0,0);

            GameObject bu= Instantiate(bullet, transform.position, bullet.transform.rotation);
            bu.GetComponent<BulletController>().positiobullet(instantiatePoint);
        }
        
    }
}
