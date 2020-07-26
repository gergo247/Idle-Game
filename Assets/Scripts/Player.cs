using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Character target;
    private Character character;

    [SerializeField]
    Animator animator;

    bool canAttack = true;
    float autoAttackCurrentTime;


    void Start()
    {
        character = GetComponent<Character>();
        animator = GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        if (character.dead)
        {
            return;
        }

        if (target == null)
        {
            LookForClosestEnemy();
            return;
        }

        
        Attack();
    }
    void Attack()
    {
        if (canAttack)
            if (autoAttackCurrentTime < character.autoAttackCooldown)
            {
                autoAttackCurrentTime += Time.deltaTime;
            }
            else
            {
                //play attack animation
                animator.SetTrigger("Sword1");
                Debug.Log("Attack animation");

                autoAttackCurrentTime = 0;
            }
    }

    public void DamageTargetFromAnimation()
    {
        if (target != null)
            target.TakeDamage(character.damage);
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
                {
                    float distanceToTarget = Vector2.Distance(tempTarget.rb.position, currentPosition);
                    Debug.Log("distanceToTarget :" + distanceToTarget);

                    if (distanceToTarget < minDist)
                    {
                        minDist = distanceToTarget;
                        target = tempTarget;
                        Debug.Log("target set");

                    }
                }
            }
        }
    }
}
