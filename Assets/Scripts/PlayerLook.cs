using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rotationSpeed;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
    }
}
