using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed;
    public float normalSpeed;
    public float fastSpeed;

    private void Awake()
    {
        normalSpeed = movementSpeed;
        fastSpeed = movementSpeed * 2;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        this.GetComponent<CharacterController>().Move(transform.right * x + transform.forward * z);
    }
}
