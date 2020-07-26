using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //player health 0-1 scale
    private float healthAmount;
    public float maxHealth = 100;
    public Rigidbody2D rb;
    [HideInInspector]
    public float currentHealth;

    public float damage = 10;
    public float autoAttackCooldown = 0.4f;
    public bool dead;

    [SerializeField]
    Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    public float GetHealthAmount()
    {
        healthAmount = currentHealth / maxHealth;
        healthAmount = Mathf.Clamp(healthAmount, 0f, 1f);
        return healthAmount;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            dead = true;
            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.6f);
    }
}
