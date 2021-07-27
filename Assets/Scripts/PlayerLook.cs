using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Transform player;
    public float rotationSpeed;

    bool isTurned = false;

    private void Awake()
    {
        rotationSpeed = FindObjectOfType<VariablePasser>().sensitivity;
        FindObjectOfType<VariablePasser>().Destroy();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.Space))
        {
            if (isTurned == false)
            {
                Camera.main.transform.localEulerAngles -= new Vector3(0, 180, 0);
                isTurned = true;
            }
        }

        else if (isTurned)
        {
            isTurned = false;
            Camera.main.transform.localEulerAngles -= new Vector3(0, 180, 0);
        }
    }
}
