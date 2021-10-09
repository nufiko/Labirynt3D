using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
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
    }
}
