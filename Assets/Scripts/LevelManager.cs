using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text startText;
    public enum States
    {
        Start,
        AtLevel,
        GameOver,
        Pass
    }

    private States levelState;

    private float maxStartTimer = 5f;
    private float startTimer;
    void Start()
    {
        startTimer = maxStartTimer;
        levelState = States.Start;
    }

    void Update()
    {
        switch(levelState)
        {
            case States.Start:
                startText.gameObject.SetActive(true);
                startText.text = "Enemies are coming...";

                startTimer -= Time.deltaTime;

                if(startTimer <= 0)
                {
                    startTimer = maxStartTimer;
                    SwitchState(States.AtLevel);
                }
                break;
            case States.AtLevel:
                startText.gameObject.SetActive(false);
                break;
            case States.GameOver:
                break;
            case States.Pass:
                break;
        }
    }

    public void SwitchState(States state)
    {
        levelState = state;
    }


}
