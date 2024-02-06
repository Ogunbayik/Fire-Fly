using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public enum Types
    {
        Player,
        Enemy
    }

    private Types laserType;

    private float movementSpeed;
    private Vector3 movementDirection;
    void Start()
    {
        SetType(laserType);
    }

    // Update is called once per frame
    void Update()
    {
        switch(laserType)
        {
            case Types.Player:
                movementDirection = Vector3.forward;
                Movement(movementSpeed);
                break;
            case Types.Enemy:
                movementDirection = Vector3.back;
                Movement(movementSpeed);
                break;
        }
    }
    public void Movement(float speed)
    {
        movementSpeed = speed;
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    public void SetType(Types type)
    {
        laserType = type;
    }

    private void OnTriggerEnter(Collider other)
    {
        var ufo = other.gameObject.GetComponent<Ufo>();
        var player = other.gameObject.GetComponent<PlayerController>();

        if (ufo)
        {
            Destroy(this.gameObject);
            Destroy(ufo.gameObject);
        }
        else if (player)
        {
            Destroy(this.gameObject);
        }
    }

}
