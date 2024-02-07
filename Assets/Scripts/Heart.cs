using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public enum States
    {
        Idle,
        Dead,
        Regain
    }
    public States currentState;
    private RectTransform currentPosition;

    private float movementSpeed = 1f;
    private float maximumY = 1180f;
    private float minimumY = 1040f;
    void Start()
    {
        currentState = States.Idle;
        currentPosition = GetComponent<RectTransform>();
    }

    void Update()
    {
        switch(currentState)
        {
            case States.Idle:
                GetNextCurrentPosition();
                break;
            case States.Dead:
                if(currentPosition.position.y < maximumY)
                {
                    var desiredPosition = new Vector3(currentPosition.position.x, maximumY, currentPosition.position.z);
                    currentPosition.position = Vector3.MoveTowards(currentPosition.position, desiredPosition, movementSpeed);
                }
                else
                {
                    currentState = States.Idle;
                }
                break;
            case States.Regain:
                if(currentPosition.position.y > minimumY)
                {
                    var desiredPosition = new Vector3(currentPosition.position.x, minimumY, currentPosition.position.z);
                    currentPosition.position = Vector3.MoveTowards(currentPosition.position, desiredPosition, movementSpeed);
                }
                else
                {
                    currentState = States.Idle;
                }
                break;
        }
    }

    public void SwitchState(States state)
    {
        currentState = state;
    }

    private RectTransform GetNextCurrentPosition()
    {
        return currentPosition;
    }



}
