using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThinkpadLogic : MonoBehaviour
{
    public bool isGlitched;

    public float speedIncrement;

    [SerializeField] Image problem1, problem2, problem3, questionBackground;
    [SerializeField] Text questionText, problemText;
    [SerializeField] Sprite glitchedBackground;

    Main main;

    public int currentProblem;

    private void Awake()
    {
        main = GetComponent<Main>();
    }

    public void Reset()
    {
        problem1.color = problem2.color = problem3.color = new Color(1, 1, 1);
        questionText.text = problemText.text = "";
    }

    void Complete()
    {
        if (isGlitched)
        {
            questionBackground.sprite = null;
        }

        GetComponent<BananaCounter>().UpdateBananas();

        GetComponent<Main>().HideThinkpad();
    }

    public void StartProcess()
    {
        switch (currentProblem)
        {
            case 1:
                questionText.text = "JUNGLE CLASS Q1:";
                problemText.text = GetComponent<ProblemManager>().firstProblem;
                break;

            case 2:
                questionText.text = "JUNGLE CLASS Q2:";
                problemText.text = GetComponent<ProblemManager>().secondProblem;
                break;

            case 3:
                if (isGlitched)
                {
                    questionBackground.sprite = glitchedBackground;
                }

                questionText.text = "JUNGLE CLASS Q3:";
                problemText.text = GetComponent<ProblemManager>().thirdProblem;
                break;
        }
    }

    public void Answer(int answer)
    {
        switch (currentProblem)
        {
            case 1:
                if (answer == GetComponent<ProblemManager>().firstAnswer)
                {
                    problem1.color = new Color(0, 1, 0);
                    // good stuff
                }

                else
                {
                    problem1.color = new Color(1, 0, 0);

                    if (main.currentState == Main.Moist_Towelette_.HAPPY)
                    {
                        main.UpdateState(Main.Moist_Towelette_.ANGRY);
                        main.youssefManager.ChangeState(1);
                        main.youssefManager.PlayMusic();
                        main.youssef.GetComponent<YoussefChase>().StartMoving();
                    }

                    else
                    {
                        main.youssef.GetComponent<YoussefChase>().GetComponent<UnityEngine.AI.NavMeshAgent>().speed += speedIncrement;
                    }
                    // bad stuff
                }

                currentProblem += 1;
                StartProcess();
                break;

            case 2:
                if (answer == GetComponent<ProblemManager>().secondAnswer)
                {
                    problem2.color = new Color(0, 1, 0);
                }

                else
                {
                    problem2.color = new Color(1, 0, 0);

                    if (main.currentState == Main.Moist_Towelette_.HAPPY)
                    {
                        main.UpdateState(Main.Moist_Towelette_.ANGRY);
                        main.youssefManager.ChangeState(1);
                        main.youssefManager.PlayMusic();
                        main.youssef.GetComponent<YoussefChase>().StartMoving();
                    }

                    else
                    {
                        main.youssef.GetComponent<YoussefChase>().GetComponent<UnityEngine.AI.NavMeshAgent>().speed += speedIncrement;
                    }
                }

                currentProblem += 1;
                StartProcess();
                break;

            case 3:
                if (answer == GetComponent<ProblemManager>().thirdAnswer && isGlitched == false)
                {
                    problem3.color = new Color(0, 1, 0);
                }

                else
                {
                    problem3.color = new Color(1, 0, 0);

                    if (main.currentState == Main.Moist_Towelette_.HAPPY)
                    {
                        main.UpdateState(Main.Moist_Towelette_.ANGRY);
                        main.youssefManager.ChangeState(1);
                        main.youssefManager.PlayMusic();
                        main.youssef.GetComponent<YoussefChase>().StartMoving();
                    }

                    else
                    {
                        main.youssef.GetComponent<YoussefChase>().GetComponent<UnityEngine.AI.NavMeshAgent>().speed += speedIncrement;
                    }
                }

                currentProblem += 1;
                Invoke("Complete", 0.75f);
                break;
        }
    }
}
