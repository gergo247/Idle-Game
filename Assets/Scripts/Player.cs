using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player theInstance;


    private Character target;
    [SerializeField]
    private Character character;

    [SerializeField]
    Animator animator;

    bool canAttack = true;
    float autoAttackCurrentTime;

    public float baseDamage = 10;
    public float upgradeDamage = 0;
    public float autoAttackCooldown = 1f;

    bool swordAttackUnlocked = false;
    void Start()
    {
        if (theInstance == null)
            theInstance = this;

        character = GetComponent<Character>();
        animator = GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        if (character.dead)
        {
            return;
        }

        if (target == null || target.dead)
        {
            LookForClosestEnemy();
            return;
        }

        Attack();
    }
    void Attack()
    {
        if (canAttack)
            if (autoAttackCurrentTime < autoAttackCooldown)
            {
                autoAttackCurrentTime += Time.deltaTime;
            }
            else
            {
                //play attack animation
                // animator.ResetTrigger("Sword1");
                int random = UnityEngine.Random.Range(1, 4);
                Debug.Log("Random attack :" + random);
                if (swordAttackUnlocked)
                {
                    switch (random)
                    {
                        case 1:
                            animator.SetTrigger("Sword1");
                            break;
                        case 2:
                            animator.SetTrigger("Sword2");
                            break;
                        case 3:
                            animator.SetTrigger("Sword3");
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (random)
                    {
                        case 1:
                            animator.SetTrigger("Unarmed1");
                            break;
                        case 2:
                            animator.SetTrigger("Unarmed2");
                            break;
                        case 3:
                            animator.SetTrigger("Unarmed3");
                            break;

                        default:
                            break;
                    }
                }
                autoAttackCurrentTime = 0;
            }
    }

    public void UnlockSwordAttack()
    {
        swordAttackUnlocked = true;
    }

    public void DamageTargetFromAnimation()
    {
        if (target != null)
            target.TakeDamage(baseDamage + upgradeDamage);

        // Debug.Log("Damage : " + (baseDamage + upgradeDamage));
    }
    void LookForClosestEnemy()
    {
        GameObject[] targetGO = GameObject.FindGameObjectsWithTag("Enemy");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPosition = transform.position;
        if (targetGO != null)
        {
            //Debug.Log("targetGO found");

            foreach (GameObject go in targetGO)
            {
                Character tempTarget = go.GetComponent(typeof(Character)) as Character;
                if (!tempTarget.dead)
                {
                    float distanceToTarget = Vector2.Distance(tempTarget.rb.position, currentPosition);
                    //  Debug.Log("distanceToTarget :" + distanceToTarget);

                    if (distanceToTarget < minDist)
                    {
                        minDist = distanceToTarget;
                        target = tempTarget;
                        //Debug.Log("target set");

                    }
                }
            }
        }
    }

    public void UpgradeDamage(float damageUp)
    {
        Debug.Log("Damage up by: " + (damageUp));
        upgradeDamage += damageUp;
    }
}
