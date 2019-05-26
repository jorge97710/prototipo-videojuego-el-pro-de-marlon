using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_arm_attack_point, right_arm_attack_point,
        left_leg_attack_point, right_leg_attack_point;
    public float stand_up_timer = 2f;
    private PlayerAnimation animationScript;
    private EnemyMovement enemy_Movement;
    void Awake()
    {
        animationScript = GetComponent<PlayerAnimation>();
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemy_Movement = GetComponentInParent<EnemyMovement>();
        }
        
    }
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
    void TagLeft_Arm()
    {
        left_arm_attack_point.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeft_Arm()
    {
        left_arm_attack_point.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeft_Leg()
    {
        left_leg_attack_point.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeft_Leg()
    {
        left_leg_attack_point.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }
    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_up_timer);
        animationScript.StandUp();
    }
    void DisableMovement()
    {
        enemy_Movement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }
    void EnableMovement()
    {
        enemy_Movement.enabled = true;
        transform.parent.gameObject.layer = 10;
    
    }
    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }
    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
