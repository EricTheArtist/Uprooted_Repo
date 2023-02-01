using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform combat_lookat;
    public Transform player;
    public Transform player_obj;
    public Rigidbody rb;

    [Header("Camera Types")]
    public GameObject exploration_camera;
    public GameObject combat_camera;
    public GameObject topdown_camera;

    public float rotation_speed;
    CameraMode mode;

    [Header("TestVariables")]
    public int switch_camera_testflag = 0;

    // Start is called before the first frame update
    void Start()
    {
        mode = player.gameObject.GetComponent<CameraMode>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            switch_cam_testfunction();
        }
        //rotation orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        
        //get input for & rotate player object
        if (mode.current_mode == CameraMode.camera_mode.exploration)
        {
            exploration_camera_mode();
        }
        else if (mode.current_mode == CameraMode.camera_mode.combat)
        {
            combat_camera_mode();
        }
        else if (mode.current_mode == CameraMode.camera_mode.topdown)
        {
            top_down_camera_mode();
        }
    }

    void exploration_camera_mode()
    {
        float hori_input = Input.GetAxisRaw("Horizontal");
        float vert_input = Input.GetAxisRaw("Vertical");
        Vector3 input_direction = orientation.forward * vert_input + orientation.right * hori_input;

        if (input_direction != Vector3.zero)
        {
            player_obj.forward = Vector3.Slerp(player_obj.forward, input_direction.normalized, Time.deltaTime * rotation_speed);
        }
    }

    void combat_camera_mode()
    {
        Vector3 combat_lookat_dir = combat_lookat.position - new Vector3(transform.position.x, combat_lookat.position.y, transform.position.z);
        orientation.forward = combat_lookat_dir.normalized;

        player_obj.forward = combat_lookat_dir.normalized;
    }

    void top_down_camera_mode()
    {
        float hori_input = Input.GetAxisRaw("Horizontal");
        float vert_input = Input.GetAxisRaw("Vertical");
        Vector3 input_direction = orientation.forward * vert_input + orientation.right * hori_input;

        if (input_direction != Vector3.zero)
        {
            player_obj.forward = Vector3.Slerp(player_obj.forward, input_direction.normalized, Time.deltaTime * rotation_speed);
        }
    }

    void switch_camera(CameraMode.camera_mode new_mode)
    {
        //makes sure all cameras are deactivated before switching the correct one on.
        exploration_camera.SetActive(false);
        combat_camera.SetActive(false);
        topdown_camera.SetActive(false);
        //activates the camera depending of the camera mode
        if(new_mode == CameraMode.camera_mode.exploration)
        {
            exploration_camera.SetActive(true);
        }
        if (new_mode == CameraMode.camera_mode.combat)
        {
            combat_camera.SetActive(true);
        }
        if (new_mode == CameraMode.camera_mode.topdown)
        {
            topdown_camera.SetActive(true);
        }

        mode.current_mode = new_mode;
    }
    void switch_cam_testfunction()
    {
        if (switch_camera_testflag == 2)
        {
            switch_camera_testflag = 0;
        }
        else
        { switch_camera_testflag++; }

        //switch the camera accordingly
        if (switch_camera_testflag == 0)
        {
            switch_camera(CameraMode.camera_mode.exploration);
        }
        if (switch_camera_testflag == 1)
        {
            switch_camera(CameraMode.camera_mode.combat);
        }
        if (switch_camera_testflag == 2)
        {
            switch_camera(CameraMode.camera_mode.topdown);
        }
    }
}
