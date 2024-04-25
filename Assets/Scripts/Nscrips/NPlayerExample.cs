using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPlayerExample : BasePlayerController, IAimable, IMoveable, IAttackable
{
    rotacion CodigoRotacion;
    [SerializeField] int altura;
    Vector3 targetPosition;
    [SerializeField] float velocidad;
    [SerializeField] Transform Objetivo;
    bool SeMueve;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CodigoRotacion = GetComponent<rotacion>();
    }

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




    public void Move(Vector2 direction)
    {
        print(direction);

        if (!SeMueve)
        {
            CodigoRotacion.LaRotacion = new Vector3(-direction.y, direction.x, 0);
        }
        

    }






    public void Attack(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "piso" && !SeMueve)
        {
            SeMueve = true;
            targetPosition = hit.point;

            targetPosition.y = transform.position.y;
            Objetivo.position = targetPosition;

            CodigoRotacion.angulos = (targetPosition - transform.position);
            //CodigoRotacion.angulos = CalculateLookRotation();



            //transform.position += transform.forward * Time.deltaTime * desiredSpeed;


            // Movemos el objeto hacia esa posición
            //transform.position = targetPosition;
        }
        //.position = position;
        Debug.Log("Attack from " + this.name);
    }



    private void Update()
    {
        Vector3 Direccion = targetPosition - transform.position;
        if ((Direccion).magnitude > 1)
        {
            transform.position += Direccion.normalized * Time.deltaTime * velocidad;
        }
        else
        {
            SeMueve = false;
        }
    }




}
