using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemManager : MonoBehaviour
{
    public string firstProblem, secondProblem, thirdProblem;
    public int firstAnswer, secondAnswer, thirdAnswer;
    public void GenerateProblems()
    {
        FirstProblem();
        SecondProblem();
        ThirdProblem();
    }

    public void FirstProblem()
    {
        int sign1 = 1;
        int sign2 = 1;

        if (Random.Range(0, 1f) > 0.5f) { sign1 = -1; }
        if (Random.Range(0, 1f) > 0.5f) { sign2 = -1; }

        int firstNumber = Random.Range(0, 20) * sign1;
        int secondNumber = Random.Range(0, 20) * sign2;

        if (sign2 == 1)
        {
            firstProblem = firstNumber + " + " + secondNumber;
        }

        else
        {
            firstProblem = firstNumber + " - " + Mathf.Abs(secondNumber);
        }

        firstAnswer = firstNumber + secondNumber;
    }

    public void SecondProblem()
    {
        int sign1 = 1;
        int sign2 = 1;
        int sign3 = 1;

        string colon3;
        string colon2;

        string firstString;
        string secondString;

        bool mult1 = false;
        bool mult2 = false;

        if (Random.Range(0, 1f) > 0.5f) { sign1 = -1; } if (Random.Range(0, 1f) > 0.5f) { sign2 = -1; } if (Random.Range(0, 1f) > 0.5f) { sign3 = -1; }
        if (Random.Range(0, 1f) > 0.5f) { mult1 = true; } if (Random.Range(0, 1f) > 0.5f) { mult2 = true; }
        if (sign2 == 1) { colon2 = "+"; } else { colon2 = "-"; } if (sign3 == 1) { colon3 = "+"; } else { colon3 = "-"; }
        int firstNumber = Random.Range(0, 7) * sign1; int secondNumber = Random.Range(0, 7) * sign2; int thirdNumber = Random.Range(0, 7) * sign3;

        if (mult1)
        {
            firstString = firstNumber + " * ";
            secondString = secondNumber.ToString();
        }

        else
        {
            firstString = firstNumber.ToString();
            secondString = " " + colon2 + " " + sign2 * secondNumber;
        }

        if (mult2)
        {
            secondString += " * " + thirdNumber;
        }

        else
        {
            secondString += " " + colon3 + " " + sign3 * thirdNumber;
        }

        secondProblem = firstString + secondString;

        if (mult1 && mult2)
        {
            secondAnswer = firstNumber * secondNumber * thirdNumber;
        }

        else if (mult1 && mult2 == false)
        {
            secondAnswer = firstNumber * secondNumber + thirdNumber;
        }

        else if (mult1 == false && mult2)
        {
            secondAnswer = firstNumber + secondNumber * thirdNumber;
        }

        else
        {
            secondAnswer = firstNumber + secondNumber + thirdNumber;
        }
    }

    public void ThirdProblem()
    {
        int sign1 = 1;
        int sign2 = 1;
        int sign3 = 1;

        string colon3;
        string colon2;

        string firstString;
        string secondString;

        bool mult1 = false;
        bool mult2 = false;

        if (Random.Range(0, 1f) > 0.5f) { sign1 = -1; }
        if (Random.Range(0, 1f) > 0.5f) { sign2 = -1; }
        if (Random.Range(0, 1f) > 0.5f) { sign3 = -1; }
        if (Random.Range(0, 1f) > 0.5f) { mult1 = true; }
        if (Random.Range(0, 1f) > 0.5f) { mult2 = true; }
        if (sign2 == 1) { colon2 = "+"; } else { colon2 = "-"; }
        if (sign3 == 1) { colon3 = "+"; } else { colon3 = "-"; }
        int firstNumber = Random.Range(1, 6) * sign1; int secondNumber = Random.Range(1, 7) * sign2; int thirdNumber = Random.Range(1, 8) * sign3;

        if (mult1)
        {
            firstString = firstNumber + " * ";
            secondString = secondNumber.ToString();
        }

        else
        {
            firstString = firstNumber.ToString();
            secondString = " " + colon2 + " " + sign2 * secondNumber;
        }

        if (mult2)
        {
            secondString += " * " + thirdNumber;
        }

        else
        {
            secondString += " " + colon3 + " " + sign3 * thirdNumber;
        }

        thirdProblem = firstString + secondString;

        if (mult1 && mult2)
        {
            thirdAnswer = firstNumber * secondNumber * thirdNumber;
        }

        else if (mult1 && mult2 == false)
        {
            thirdAnswer = firstNumber * secondNumber + thirdNumber;
        }

        else if (mult1 == false && mult2)
        {
            thirdAnswer = firstNumber + secondNumber * thirdNumber;
        }

        else
        {
            thirdAnswer = firstNumber + secondNumber + thirdNumber;
        }
    }
}
