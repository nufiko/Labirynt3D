using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = 9.81f;

    Vector3 gravityVelocity;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        RaycastHit hit;

        if(
            Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
                    out hit, 0.4f, groundMask)
        )
        {
            gravityVelocity = Vector3.zero;
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
                default:
                    speed = 12;
                    break;
            }
        }
        else
        {
            DropPlayer();
        }
    }

    public void DropPlayer()
    {
        gravityVelocity += Vector3.down * gravity * Time.deltaTime;
        characterController.Move(gravityVelocity * Time.deltaTime);
    }

    /// <summary>
    /// OnControllerColliderHit is called when the controller hits a
    /// collider while performing a Move.
    /// </summary>
    /// <param name="hit">The ControllerColliderHit data associated with this collision.</param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.LogWarning(hit.gameObject.tag);
        if(hit.gameObject.CompareTag("PickUp"))
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
