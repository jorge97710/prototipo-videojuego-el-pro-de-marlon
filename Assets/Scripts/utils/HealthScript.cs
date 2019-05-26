﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private PlayerAnimation animationScript;
    private EnemyMovement enemyMovement;
    private bool characterDied;
    public bool is_Player;
    void Awake()
    {
        animationScript = GetComponentInChildren<PlayerAnimation>();
        
    }
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;
        health -= damage;
        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;
            if (is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;


            }
            return;
        }
        if (!is_Player)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
        if (is_Player)
        {
            animationScript.Hit();

            
        }

    }

}
