using System;
using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;

    private Rigidbody myBody;
    public float enemy_speed = 5f;

    private Transform playerTarget;

    public float attack_Distance = 1f;
    private float chase_player_after_attack = 1f;

    private float current_attack_time;
    private float default_attack_time = 2f;

    private bool followPlayer, attackPlayer;

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(TagManager.Tags.PLAYER_TAG).transform;
    }

    void Start()    
    {
        followPlayer = true;
        current_attack_time = default_attack_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
            FollowTarget();
        else if (attackPlayer)
            Attack();
    }

    void FollowTarget()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
        else
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * enemy_speed;

            enemyAnim.Walk(true);
            attackPlayer = false;
        }
    }


    void Attack()
    {
        current_attack_time += Time.deltaTime;

        if (current_attack_time > default_attack_time)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            current_attack_time = 0f;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer > attack_Distance + chase_player_after_attack)
        {
            attackPlayer = false;
            followPlayer = true;

        }
    }
}
