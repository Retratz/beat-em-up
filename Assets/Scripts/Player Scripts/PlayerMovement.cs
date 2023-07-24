using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Animation;

    private Rigidbody mybody;
    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;
    
    private float rotation_Y = -90f;
    private float rotation_speed = 15f;
    
    void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        player_Animation = GetComponentInChildren<CharacterAnimation>();

    }

    private void Update()
    {
        rotate_player();
        AnimatePlayerWalk();
    }


    void FixedUpdate()
    {
        detect_movement();
    }

    void detect_movement()
    {
        mybody.velocity = new Vector3(
            Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            mybody.velocity.y,
            Input.GetAxisRaw(TagManager.Axis.VERTICAL_AXIS) * (-z_Speed));
    }

    void rotate_player()
    {
        if (Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f,rotation_Y,0f);
        }else if(Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_Y),0f);
        }
    }

    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(TagManager.Axis.HORIZONTAL_AXIS) != 0 ||
            Input.GetAxisRaw(TagManager.Axis.VERTICAL_AXIS) != 0)
        {
            
            
            
            player_Animation.Walk(true);
        }
        else
        {
            player_Animation.Walk(false);
        }
    }
}
