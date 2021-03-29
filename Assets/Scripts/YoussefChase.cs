using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YoussefChase : MonoBehaviour
{
    [SerializeField] Image funny;

    [SerializeField] AudioClip jumpscare;

    public GameObject player;

    Vector3 distanceTo;

    NavMeshAgent navMeshAgent;

    bool shouldFollow;

    public float jumpscareDistance;

    void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        distanceTo = this.transform.position - player.transform.position;
        this.transform.rotation = Quaternion.LookRotation(distanceTo);
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + 90, 0);

        if (shouldFollow)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) > jumpscareDistance)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
            
            else
            {
                shouldFollow = false;
                navMeshAgent.velocity = Vector3.zero;
                navMeshAgent.isStopped = true;
                FindObjectOfType<Main>().ShowThinkpad();
                funny.gameObject.SetActive(true);
                this.GetComponent<YoussefManager>().soundtrack.Stop();
                this.GetComponent<YoussefManager>().soundtrack.loop = false;
                this.GetComponent<YoussefManager>().soundtrack.clip = jumpscare;
                this.GetComponent<YoussefManager>().soundtrack.Play();
                Invoke("Quit", 2.15f);
            }
        }
    }

    private void Awake()
    {
        funny.gameObject.SetActive(false);    
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void StartMoving()
    {
        shouldFollow = true;
    }
}
