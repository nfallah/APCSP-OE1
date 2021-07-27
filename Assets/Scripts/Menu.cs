
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject test;

    private void Start()
    {
        test.GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
}
