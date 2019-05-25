using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_arm_attack_point, right_arm_attack_point,
        left_leg_attack_point, right_leg_attack_point;
    void Left_arm_attack_on()
    {
        left_arm_attack_point.SetActive(true);

    }
    void Left_arm_attack_off()
    {
        if (!left_arm_attack_point.activeInHierarchy)
        {
            left_arm_attack_point.SetActive(false);
         
        }
    }
    void Right_arm_attack_on()
    {
        right_arm_attack_point.SetActive(true);
       
    }
    void Right_arm_attack_off()
    {
        if (!right_arm_attack_point.activeInHierarchy)
        {
            right_arm_attack_point.SetActive(false);
            
        }
    }
    void Left_leg_attack_on()
    {
        left_leg_attack_point.SetActive(true);
    }
    void Left_leg_attack_off()
    {
        if (left_leg_attack_point.activeInHierarchy)
        {
            left_leg_attack_point.SetActive(false);
        }
    }
    void Right_leg_attack_on()
    {
        right_leg_attack_point.SetActive(true);
    }
    void Right_leg_attack_off()
    {
        if (right_leg_attack_point.activeInHierarchy)
        {
            right_leg_attack_point.SetActive(false);
        }
    }
}
