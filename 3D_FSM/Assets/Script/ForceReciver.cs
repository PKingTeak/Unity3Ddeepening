using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciver : MonoBehaviour
{
    private CharacterController controller;

    private float VerticalVelocity;

    public Vector3 movement => Vector3.up * VerticalVelocity; //위로 갈지 아로 갈지
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //중력을 게산하지 않을까?
        if (controller.isGrounded)
        {

            VerticalVelocity = Physics.gravity.y * Time.deltaTime; //중력 영향을 받지
        }
        else
        {

            VerticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

    }

    public void Jump(float jumpForce)
    {

        VerticalVelocity += jumpForce;
     }
}
