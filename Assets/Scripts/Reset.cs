using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && FindObjectOfType<YoussefChase>().isScared == false)
        {
            GameObject test = new GameObject();
            test.AddComponent<VariablePasser>();
            test.GetComponent<VariablePasser>().sensitivity = FindObjectOfType<PlayerLook>().rotationSpeed;
            SceneManager.LoadScene(1);
        }

        else if (Input.GetKeyDown(KeyCode.M) && FindObjectOfType<YoussefChase>().isScared == false)
        {
            GameObject test = new GameObject();
            test.AddComponent<FunnyPass>();
            test.GetComponent<FunnyPass>().sens = FindObjectOfType<PlayerLook>().rotationSpeed;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
