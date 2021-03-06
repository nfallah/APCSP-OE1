using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaDetection : MonoBehaviour
{
    [SerializeField] float raycastDistance;
    [SerializeField] LayerMask bananaLayer;
    public Sprite crosshair1, crosshair2;
    public KeyCode bananaKey;

    public Image crosshair;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, raycastDistance, bananaLayer))
        {
            if (crosshair.sprite != crosshair2)
            {
                crosshair.sprite = crosshair2;
            }

            if (Input.GetKeyDown(bananaKey))
            {
                GetComponent<ProblemManager>().GenerateProblems(raycastHit.transform.gameObject.GetComponent<BananaProperties>().isGlitched);
                GetComponent<ThinkpadLogic>().currentProblem = 1;

                if (raycastHit.transform.gameObject.GetComponent<BananaProperties>().isGlitched)
                {
                    GetComponent<ThinkpadLogic>().isGlitched = true;
                }

                else
                {
                    GetComponent<ThinkpadLogic>().isGlitched = false;
                }

                GetComponent<ThinkpadLogic>().StartProcess();
                GetComponent<Main>().ShowThinkpad();
                Destroy(raycastHit.transform.gameObject);
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
