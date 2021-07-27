using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public GameObject trigger;

    [SerializeField] AudioClip finalBoss;
    [SerializeField] Image ending;

    [SerializeField] Text run;

    public enum Moist_Towelette_ { ANGRY, HAPPY }

    public Moist_Towelette_ currentState;

    public Image thinkpad;
    public Sprite thinkpadAngry;
    public Sprite thinkpadHappy;

    public GameObject[] images;
    public GameObject buttons;

    public GameObject youssef;
    public YoussefManager youssefManager;

    void OpenLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Victory()
    {
        youssef.SetActive(false);
        ending.gameObject.SetActive(true);
        Invoke("OpenLevel", 2.15f);
    }

    public void VictoryCondition()
    {
        youssefManager.soundtrack.Stop();
        youssefManager.soundtrack.clip = finalBoss;
        youssefManager.soundtrack.Play();
        youssef.GetComponent<YoussefChase>().GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 17.5f;
        FindObjectOfType<PlayerMove>().normalSpeed = 12.5f;
        FindObjectOfType<PlayerMove>().fastSpeed = 20;
        FindObjectOfType<PlayerMove>().movementSpeed = 12.5f;
        trigger.SetActive(true);
        run.gameObject.SetActive(true);
        ShowThinkpad();
    }

    private void Awake()
    {
        youssefManager = youssef.GetComponent<YoussefManager>();
        youssefManager.ChangeState(0);
        run.gameObject.SetActive(false);
        trigger.SetActive(false);
        ending.gameObject.SetActive(false);
    }

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
        GetComponent<SprintManager>().Deactivate();
        FindObjectOfType<PlayerMove>().movementSpeed = 0;
        FindObjectOfType<PlayerLook>().enabled = false;
        GetComponent<BananaCounter>().bananaText.gameObject.SetActive(false);
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
        GetComponent<SprintManager>().Reactivate();
        FindObjectOfType<PlayerMove>().movementSpeed = FindObjectOfType<PlayerMove>().normalSpeed;
        FindObjectOfType<PlayerLook>().enabled = true;
        GetComponent<BananaCounter>().bananaText.gameObject.SetActive(true);
    }
}
