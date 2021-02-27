using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    public float speed = 12f;
    public float grav = -10f;
    Vector3 velocity;
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

        velocity.y += grav * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);
    }
}
