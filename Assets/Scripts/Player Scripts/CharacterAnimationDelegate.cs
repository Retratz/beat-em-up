using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_arm_attack, right_arm_attack, left_leg_attack, right_leg_attack;

    void left_arm_attack_on()
    {
        left_arm_attack.SetActive(true);
    }
    void left_arm_attack_off()
    {
        if (left_arm_attack.activeInHierarchy)
        {
            left_arm_attack.SetActive(false);
        }
    }
    void right_arm_attack_on()
    {
        right_arm_attack.SetActive(true);
    }
    void right_arm_attack_off()
    {
        if (right_arm_attack.activeInHierarchy)
        {
            right_arm_attack.SetActive(false);
        }
    }

    void left_leg_attack_on()
    {
        left_leg_attack.SetActive(true);
    }
    void left_leg_attack_off()
    {
        if (left_arm_attack.activeInHierarchy)
        {
            left_leg_attack.SetActive(false);

        }
    }
    void right_leg_attack_on()
    {
        right_leg_attack.SetActive(true);
    }
    void right_leg_attack_off()
    {
        if (right_arm_attack.activeInHierarchy)
        {
            right_leg_attack.SetActive(false);
        }
    }
}
