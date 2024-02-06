using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    private float minimumSpeed = 2;
    private float maximumSpeed = 5;
    private float movementSpeed;
    void Start()
    {
        movementSpeed = Random.Range(minimumSpeed, maximumSpeed);
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
    }

}
