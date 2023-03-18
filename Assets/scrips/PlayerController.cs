using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ///Public Variables
    [Header("Movement")]
    public float current_spped;
    public float ground_drag;
    public Transform orientation;

    [Header("Jump/Air Control")]
    public float jump_force;
    public float jump_cooldown;
    public float air_multiplier;
    public bool can_jump;

    [Header("Ground Check")]
    public bool is_grounded;
    public float player_height;
    public LayerMask ground_layer;

    [Header("Key Bindings")]
    public KeyCode jump_key = KeyCode.Space;
    ///Private Variables
    float hori_input;
    float vert_input;
    Vector3 move_direction;
    Rigidbody rb;

    [Header("References")]
    CameraMode camera_mode;

    [Header("Animation")]
    public Animator C_Animator;

    void Start()
    {
        camera_mode = this.GetComponent<CameraMode>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        can_jump = true;
    }
    void Update()
    {
        //Get The Player Inputs
        get_inputs();
        
        
    }
    private void FixedUpdate()
    {
        move_player();
        //maintians and checks the max speed
        speed_control();
        //maintains and checks ground movement
        ground_control();
        //Debug.Log("Velocity: " + rb.velocity.magnitude);
        if (rb.velocity.magnitude > 5)
        {
            C_Animator.SetBool("Running", true);
        }
        else
        {
            C_Animator.SetBool("Running", false);
        }
    }

    void get_inputs()
    {
        //get key inputs from player
        //Raw allows us to so that we avoid the smoothing
        hori_input = Input.GetAxisRaw("Horizontal");
        vert_input = Input.GetAxisRaw("Vertical");

        //jump key input
        if(Input.GetKey(jump_key) && is_grounded && can_jump)
        {
            C_Animator.SetTrigger("Jump"); // trigger for jump animation -Eric
            can_jump = false;

            if (rb.velocity.magnitude > 5) // Check to delay jump for static jump animation
            {
                jump_control();
                Invoke(nameof(reste_jump), jump_cooldown);

            }
            else
            {
                StartCoroutine(StandingJumpDelay());
            }

        }
    }

    IEnumerator StandingJumpDelay()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);

        jump_control();
        Invoke(nameof(reste_jump), jump_cooldown);
    }


    void move_player()
    {

        //calculating the movement direction
        move_direction = orientation.forward * vert_input + orientation.right * hori_input;
        //adding the force in the direction we calculated above to move the player while grounded
        if(is_grounded)
            rb.AddForce(move_direction.normalized * current_spped, ForceMode.Force);
        //add force while the player is in the air
        else if(!is_grounded)
            rb.AddForce(move_direction.normalized * current_spped *air_multiplier, ForceMode.Force);

    }
    void ground_control()
    {
        is_grounded = Physics.Raycast(transform.position,Vector3.down , player_height * 0.5f + 0.2f, ground_layer);

        if (is_grounded)
        {
            rb.drag = ground_drag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    void speed_control()
    {
        //limits speed manually
        //we need to obtain the flat velocity from the x and z axis
        Vector3 flat_velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //if this flat velocity exceeds the movement speed set

        if (flat_velocity.magnitude > current_spped)
        {
            //calculate what the max velocity is
            Vector3 limited_velocity = flat_velocity.normalized * current_spped;
            //apply that limited max velocity to your rigidbody
            rb.velocity = new Vector3(limited_velocity.x, rb.velocity.y, limited_velocity.z);
        }
    }
    void jump_control()
    {
            
        //Debug.Log("Is jumping");
        //reset the y value so that player always jumps at the same height
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //add an impluse force in the upwards direction of the transform
        //rb.AddForce(transform.up * jump_force, ForceMode.Impulse);
        rb.velocity = new Vector3(rb.velocity.x,Mathf.Sqrt(-2f * Physics.gravity.y * jump_force), rb.velocity.z);
    }
    void reste_jump()
    {
        can_jump = true;
    }



}
