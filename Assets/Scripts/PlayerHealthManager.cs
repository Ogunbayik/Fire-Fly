using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private Image[] heartImages;
    [SerializeField] private Sprite heartSprite;
    [SerializeField] private Sprite devilHeartSprite;

    [SerializeField] private int maxHealth;

    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;

        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].sprite = heartSprite;
        }
    }
    private void Update()
    {
        CheckDead();
    }

    private void CheckDead()
    {
        if (currentHealth <= 0)
            Debug.Log("You are Dead!");
    }

    public void IncreaseHealth()
    {
        if (currentHealth >= maxHealth)
        {
            Debug.Log("Have max Health");
        }
        else
        {
            currentHealth++;
            var lastIndex = currentHealth - 1;
            var lastImage = heartImages[lastIndex];
            lastImage.sprite = heartSprite;

            heartImages[lastIndex].GetComponent<Heart>().SwitchState(Heart.States.Regain);
        }
    }

    public void DecreaseHealth()
    {
        var lastIndex = currentHealth - 1;
        var lastImage = heartImages[lastIndex];
        currentHealth--;
        lastImage.sprite = devilHeartSprite;

        heartImages[lastIndex].GetComponent<Heart>().SwitchState(Heart.States.Dead);
    }

    private void OnTriggerEnter(Collider other)
    {
        var ufo = other.gameObject.GetComponent<Ufo>();

        if (ufo)
        {
            Destroy(ufo.gameObject);
            DecreaseHealth();
        }
    }
}
