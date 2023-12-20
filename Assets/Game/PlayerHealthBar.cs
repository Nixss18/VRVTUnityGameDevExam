using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    public HealthBarPlayer healthBar;


    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetSlider(currentHealth);


        if (currentHealth <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        SceneManager.LoadScene("EndScreen");
    }

}
