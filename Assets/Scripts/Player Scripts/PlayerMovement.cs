using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation player_anim;
    private Rigidbody myBody;
    public float walk_speed = 3f;
    public float z_speed = 1.5f;
    private float rotation_y = -90f;
    private float rotation_speed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        player_anim = GetComponentInChildren<PlayerAnimation>();
        myBody = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();

    }
    void FixedUpdate()
    {
        DetectMovement();
    }
    void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS)*(-z_speed));
    }
    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotation_y),0f);
        }else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_y),0f);
        }
    }
    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)!=0 ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_anim.Walk(true);

        }
        else
        {
            player_anim.Walk(false);
        }

    }
}
