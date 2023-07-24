using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState 
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_combo_timer = .4f;
    private float current_combo_timer;

    private ComboState current_combo_state;


    // Start is called before the first frame update
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Start()
    {
        current_combo_timer = default_combo_timer;
        current_combo_state = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks() //checks attack combo timer and states
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (current_combo_state == ComboState.PUNCH_3 ||
                current_combo_state == ComboState.KICK_1 ||
                current_combo_state == ComboState.KICK_2)
                return; // exits the function
            
            current_combo_state++;
            activateTimerToReset = true;
            current_combo_timer = default_combo_timer;

            if (current_combo_state == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }

            if (current_combo_state == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }

            if (current_combo_state == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            // returns if punch 3 or kick 2
            if (current_combo_state == ComboState.PUNCH_3 ||
                current_combo_state == ComboState.KICK_2)
                return; // exits the function
            
            // sets current combo to kick 1 if the state is
            // punch 1 punch 2 or none
            if (current_combo_state == ComboState.PUNCH_1 ||
                current_combo_state == ComboState.PUNCH_2 ||
                current_combo_state == ComboState.NONE)
            {
                current_combo_state = ComboState.KICK_1;
            } else if (current_combo_state == ComboState.KICK_1)
            {
                current_combo_state++;
            }
            
            activateTimerToReset = true;
            current_combo_timer = default_combo_timer;

            if (current_combo_state == ComboState.KICK_1)
            {
                player_Anim.Kick_1();
            }

            if (current_combo_state == ComboState.KICK_2)
            {
                player_Anim.Kick_2();
            }
        }
    }

    void ResetComboState() //resets combo if no action is taken
    {
        if (activateTimerToReset)
        {
            current_combo_timer -= Time.deltaTime;
            if (current_combo_timer <= 0f)
            {
                current_combo_state = ComboState.NONE;

                activateTimerToReset = false;
                current_combo_timer = default_combo_timer;
                {

                }
            }
        }
    }
}

