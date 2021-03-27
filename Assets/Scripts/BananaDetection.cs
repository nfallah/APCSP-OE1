using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaDetection : MonoBehaviour
{
    [SerializeField] int raycastDistance;
    [SerializeField] LayerMask bananaLayer;
    public Sprite crosshair1, crosshair2;
    public KeyCode bananaKey;

    public Image crosshair;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, raycastDistance, bananaLayer))
        {
            if (crosshair.sprite != crosshair2)
            {
                crosshair.sprite = crosshair2;
            }

            if (Input.GetKeyDown(bananaKey))
            {
                GetComponent<ProblemManager>().GenerateProblems();
                GetComponent<ThinkpadLogic>().currentProblem = 1;
                GetComponent<ThinkpadLogic>().StartProcess();
                GetComponent<Main>().ShowThinkpad();
            }
        }

        else
        {
            if (crosshair.sprite != crosshair1)
            {
                crosshair.sprite = crosshair1;
            }
        }
    }
}
