using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintManager : MonoBehaviour
{
    bool shouldSprint;
    bool isDeactivated;

    [SerializeField] float stamina, recoveryRate, lossRate;
    [SerializeField] KeyCode sprintKey;

    [SerializeField] Image back, front;
    [SerializeField] Text cooldownText;

    float maxStamina, barPercent;

    PlayerMove player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMove>();
        shouldSprint = true;
        maxStamina = stamina;
        cooldownText.gameObject.SetActive(false);
        barPercent = stamina / maxStamina;
    }
    private void Update()
    {
        if (Input.GetKey(sprintKey) && shouldSprint && isDeactivated == false)
        {
            stamina = Mathf.Clamp(stamina - lossRate * Time.deltaTime, 0, maxStamina);
            barPercent = stamina / maxStamina;
            front.gameObject.transform.localScale = new Vector3(barPercent, 1, 1);
            
            if (barPercent == 0)
            {
                cooldownText.gameObject.SetActive(true);
                shouldSprint = false;
                Invoke("Continue", 2);
                player.movementSpeed = player.normalSpeed;
            }

            else
            {
                if (player.movementSpeed < player.fastSpeed)
                {
                    player.movementSpeed = player.fastSpeed;
                }
            }
        }

        else if (stamina < maxStamina && shouldSprint)
        {
            if (player.movementSpeed > player.normalSpeed)
            {
                player.movementSpeed = player.normalSpeed;
            }

            stamina = Mathf.Clamp(stamina + recoveryRate * Time.deltaTime, 0, maxStamina);
            barPercent = stamina / maxStamina;
            front.gameObject.transform.localScale = new Vector3(barPercent, 1, 1);
        }
    }

    void Continue()
    {
        cooldownText.gameObject.SetActive(false);
        shouldSprint = true;
    }

    public void Deactivate()
    {
        isDeactivated = true;
        back.gameObject.SetActive(false);
        front.gameObject.SetActive(false);
        cooldownText.gameObject.SetActive(false);
    }

    public void Reactivate()
    {
        isDeactivated = false;
        back.gameObject.SetActive(true);
        front.gameObject.SetActive(true);

        if (barPercent == 0)
        {
            cooldownText.gameObject.SetActive(true);
        }
    }
}
