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
    private PlayerAnimation player_anim;

    private bool activateTimerToReset;

    private float default_combo_timer = 0.4f;
    private float current_combo_timer;
    private ComboState current_combo_state;
    // Start is called before the first frame update
    void Awake()
    {
        player_anim = GetComponentInChildren<PlayerAnimation>();
        
    }
    void Start()
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
    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (current_combo_state == ComboState.PUNCH_3 ||
                current_combo_state == ComboState.KICK_1 ||
                current_combo_state == ComboState.KICK_2)
                return;
            current_combo_state++;
            activateTimerToReset = true;
            current_combo_timer = default_combo_timer;
            if(current_combo_state == ComboState.PUNCH_1)
            {
                player_anim.Punch_1();
            }
            if (current_combo_state == ComboState.PUNCH_2)
            {
                player_anim.Punch_2();
            }
            if (current_combo_state == ComboState.PUNCH_3)
            {
                player_anim.Punch_3();
            }

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (current_combo_state == ComboState.KICK_2 ||
                current_combo_state == ComboState.PUNCH_3)
                return;
            if(current_combo_state == ComboState.NONE||
                current_combo_state == ComboState.PUNCH_1||
                current_combo_state == ComboState.PUNCH_2)
            {
                current_combo_state = ComboState.KICK_1;
            }
            else if(current_combo_state==ComboState.KICK_1)
            {
                current_combo_state++;
            }
            activateTimerToReset = true;
            current_combo_timer = default_combo_timer;
            if (current_combo_state == ComboState.KICK_1)
            {
                player_anim.Kick_1();
            }
            if(current_combo_state == ComboState.KICK_2)
            {
                player_anim.Kick_2();
            }
        }
        
    }
    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_combo_timer -= Time.deltaTime;

            if (current_combo_timer <= 0f)
            {
                current_combo_state = ComboState.NONE;
                activateTimerToReset = false;
                current_combo_timer = default_combo_timer;

            }

        }
    }
}
