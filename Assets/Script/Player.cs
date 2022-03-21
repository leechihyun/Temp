using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController cController;

    public bool isGrounded { get; private set; }
    public LayerMask groundMask;
    public Vector3 velocity;

    public float roadWidth = 8f;
    public float moveSpeedX = 8f;
    public float moveSpeedZ = 5f;

    private void Update()
    {
        CheckIsGround();
        Gravity();

        MoveX();
        MoveZ();

        cController.Move(velocity * Time.deltaTime);
    }

    void CheckIsGround()
    {
        if (cController.isGrounded)
        {
            isGrounded = true;
            return;
        }

        Collider[] others = Physics.OverlapSphere(transform.position, cController.radius, groundMask, QueryTriggerInteraction.Ignore);

        isGrounded = others.Length > 0;
    }

    void Gravity()
    {
        if (!isGrounded)
        {
            float gravity = Physics.gravity.y;
            gravity = Mathf.Clamp(gravity, -float.MaxValue, -0.001f);
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            if (velocity.y < 0f)
                velocity.y = 0f;
        }
    }


    float desiredPositionX;
    void MoveX()
    {
        switch (DragInput.touchPhase)
        {
            case TouchPhase.Began:
            case TouchPhase.Moved:
            case TouchPhase.Stationary:
                desiredPositionX = roadWidth * DragInput.dragNormalizeX;

                velocity.x = (desiredPositionX - transform.position.x) * moveSpeedX;
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                velocity.x = 0f;
                break;
            default:
                break;
        }
    }

    void MoveZ()
    {
        velocity.z = moveSpeedZ;
    }
}
