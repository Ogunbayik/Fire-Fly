using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    private int score;
    private int maximumScore = 11;
    private int minimumScore = 5;

    private float minimumSpeed = 2;
    private float maximumSpeed = 5;
    private float movementSpeed;
    void Start()
    {
        movementSpeed = Random.Range(minimumSpeed, maximumSpeed);
        score = Random.Range(minimumScore, maximumScore);
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
    }

    public int GetScore()
    {
        return score;
    }

}
