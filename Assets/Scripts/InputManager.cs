using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Text interfaceText;
    public string playerInput;
    public int playerInputInt;

    public void Reset()
    {
        playerInput = "";
        playerInputInt = 0;
        interfaceText.text = "";
    }

    public void ThinkpadInput(string input)
    {
        if (playerInput.Length <= 5)
        {
            playerInput += input;
            playerInputInt = int.Parse(playerInput);
            interfaceText.text = playerInput;
        }
    }

    public void ThinkpadClear()
    {
        playerInput = "";
        playerInputInt = 0;
        interfaceText.text = playerInput;
    }

    public void ThinkpadMinus()
    {
        if (playerInput.Length == 0)
        {
            playerInput += "-";
            interfaceText.text = playerInput;
        }
    }

    public void ThinkpadDelete()
    {

        List<char> letters = new List<char>();

        foreach (char epic in playerInput)
        {
            letters.Add(epic);
        }

        letters.RemoveAt(letters.Count - 1);
        playerInput = "";

        foreach (char epic in letters)
        {
            playerInput += epic;
        }

        if (playerInput != "" && playerInput != "-")
        {
            playerInputInt = int.Parse(playerInput);
        }

        else
        {
            playerInputInt = 0;
        }

        interfaceText.text = playerInput;
    }

    public void ThinkpadComplete()
    {
        GetComponent<ThinkpadLogic>().Answer(playerInputInt);
        playerInput = "";
        playerInputInt = 0;
        interfaceText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            ThinkpadInput("0");
        }

        if (Input.GetKeyDown("1"))
        {
            ThinkpadInput("1");
        }

        if (Input.GetKeyDown("2"))
        {
            ThinkpadInput("2");
        }

        if (Input.GetKeyDown("3"))
        {
            ThinkpadInput("3");
        }

        if (Input.GetKeyDown("4"))
        {
            ThinkpadInput("4");
        }

        if (Input.GetKeyDown("5"))
        {
            ThinkpadInput("5");
        }

        if (Input.GetKeyDown("6"))
        {
            ThinkpadInput("6");
        }

        if (Input.GetKeyDown("7"))
        {
            ThinkpadInput("7");
        }

        if (Input.GetKeyDown("8"))
        {
            ThinkpadInput("8");
        }

        if (Input.GetKeyDown("9"))
        {
            ThinkpadInput("9");
        }

        if (Input.GetKeyDown("-"))
        {
            ThinkpadMinus();
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && playerInput.Length > 0)
        {
            ThinkpadDelete();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ThinkpadComplete();
        }
    }
}
