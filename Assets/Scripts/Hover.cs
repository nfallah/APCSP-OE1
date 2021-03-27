using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] float rotationSpeed, bopSpeed, amplitude;
    Vector3 rotation, originalPosition;
    int direction;
    float timer, timePercent;

    private void Awake()
    {
        originalPosition = this.transform.position;
        rotation = this.gameObject.transform.eulerAngles;
        if (Random.Range(0, 1f) > 0.5f)
        {
            direction = 1;
        }

        else
        {
            direction = -1;
        }

        bopSpeed /= 2f;
        timer = bopSpeed;

        InitialBop();
    }

    private void Update()
    {
        rotation.y = Mathf.Clamp(rotation.y + rotationSpeed * Time.deltaTime, 0, 360);
        
        if (rotation.y == 360)
        {
            rotation.y = 0;
        }

        this.gameObject.transform.eulerAngles = rotation;
    }

    bool Timer()
    {
        timer = Mathf.Clamp(timer - Time.deltaTime, 0, bopSpeed);
        timePercent = 1 - (timer / bopSpeed);

        if (timePercent == 1)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    void InitialBop()
    {
        if (Timer())
        {
            this.gameObject.transform.position = Vector3.Lerp(originalPosition, originalPosition + Vector3.up * direction * amplitude, timePercent);
            Invoke("InitialBop", Time.deltaTime);
        }

        else
        {
            this.gameObject.transform.position = originalPosition + amplitude * Vector3.up * direction;
            bopSpeed *= 2;
            timer = bopSpeed;

            if (direction == 1)
            {
                direction = -1;
            }

            else
            {
                direction = 1;
            }

            originalPosition = this.transform.position;
            Bop();
        }
    }

    void Bop()
    {
        if (Timer())
        {
            this.gameObject.transform.position = Vector3.Lerp(originalPosition, originalPosition + 2 * amplitude * Vector3.up * direction, timePercent);
        }

        else
        {
            this.gameObject.transform.position = originalPosition + 2 * amplitude * Vector3.up * direction;

            if (direction == 1)
            {
                direction = -1;
            }

            else
            {
                direction = 1;
            }

            timer = bopSpeed;
            originalPosition = this.transform.position;
        }

        Invoke("Bop", Time.deltaTime);
    }
}
