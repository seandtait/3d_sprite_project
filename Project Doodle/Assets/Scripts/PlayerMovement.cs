using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    Player player;

    CharacterController characterController;
    float MovementSpeed = 2;
    float RunningSpeed = 6;
    float Gravity = 9.8f;
    private float velocity = 0;

    private void Start()
    {
        player = GetComponent<Player>();
        cam = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float speed = MovementSpeed;
        if (player.running)
        {
            speed = RunningSpeed;
        }

        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        } else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
