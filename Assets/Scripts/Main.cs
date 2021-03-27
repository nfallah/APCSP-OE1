using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public enum Moist_Towelette_ { ANGRY, HAPPY }

    public Moist_Towelette_ currentState;

    public Image thinkpad;
    public Sprite thinkpadAngry;
    public Sprite thinkpadHappy;

    public GameObject[] images;
    public GameObject buttons;

    private void Start()
    {
        UpdateState(Moist_Towelette_.HAPPY);
        HideThinkpad();
    }

    public void UpdateState(Moist_Towelette_ newState)
    {
        currentState = newState;

        switch (newState)
        {
            case Moist_Towelette_.ANGRY:
                thinkpad.sprite = thinkpadAngry;
                break;

            case Moist_Towelette_.HAPPY:
                thinkpad.sprite = thinkpadHappy;
                break;
        }
    }

    public void ShowThinkpad()
    {
        buttons.SetActive(true);

        foreach (GameObject I in images)
        {
            I.SetActive(true);
        }

        thinkpad.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        GetComponent<InputManager>().enabled = true;
        GetComponent<BananaDetection>().crosshair.gameObject.SetActive(false);
        GetComponent<BananaDetection>().enabled = false;
        GetComponent<ThinkpadLogic>().enabled = true;
        GetComponent<ProblemManager>().enabled = true;

        // make sure to disable movement
        // also remove sprint meter on the bottom
    }

    public void HideThinkpad()
    {
        buttons.SetActive(false);

        foreach (GameObject I in images)
        {
            I.SetActive(false);
        }

        GetComponent<InputManager>().Reset();
        GetComponent<InputManager>().enabled = false;
        thinkpad.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<BananaDetection>().enabled = true;
        GetComponent<BananaDetection>().crosshair.gameObject.SetActive(true);
        GetComponent<ThinkpadLogic>().Reset();
        GetComponent<ThinkpadLogic>().enabled = false;
        GetComponent<ProblemManager>().enabled = false;

        // make sure to reenable movement
        // show sprint bar again
    }
}
