using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;

    public TextMeshProUGUI health;
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    public int damage;
    public int armor;

    public event System.Action<int, int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
        StartCoroutine(HealthIncrease());
        health.text = "Health: " + maxHealth.ToString();
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
            health.text = "Health: " + currentHealth.ToString();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(int restore)
    {
        currentHealth = Mathf.Clamp(currentHealth + restore, 0, maxHealth);

        Debug.Log(currentHealth);

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
            health.text = "Health: " + currentHealth.ToString();
        }
    }

    IEnumerator HealthIncrease()
    {
        for (int x = 1; x <= maxHealth; x++)
        {
            currentHealth = x;
            if (OnHealthChanged != null)
            {
                OnHealthChanged(maxHealth, currentHealth);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(10);
        }
    }
}
