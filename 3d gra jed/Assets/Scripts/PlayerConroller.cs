using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    public float speed = 12f;
    public float grav = -10f;
    Vector3 velocity;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        charController.Move(move * speed * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        velocity.y += grav * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);
        RaycastHit hit;
        if(Physics.Raycast(
            groundCheck.position,
            transform.TransformDirection(Vector3.down),
            out hit,
            0.4f,
            groundMask))
        {
            string TerrainType;
            TerrainType = hit.collider.gameObject.tag;
            switch(TerrainType)
            {
                default:
                    speed = 12;
                    break;
                case "LowPlane":
                    speed = 3;
                    break;
                case "HigPlane":
                    speed = 20;
                    break;

            }
        }    
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUps>().Picked();
        }
    }
}
