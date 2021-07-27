using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariablePasser : MonoBehaviour
{
    [SerializeField] Text sliderText;
    [SerializeField] Slider slider;

    public float sensitivity;

    public void UpdateSens()
    {
       sensitivity = slider.value * 50;
       sliderText.text = "Sensitivity: " + sensitivity.ToString();
    }

    private void Start()
    {
        DontDestroyOnLoad(this);

        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (FindObjectOfType<FunnyPass>() != null)
            {
                slider.value = FindObjectOfType<FunnyPass>().sens / 50f;
                FindObjectOfType<FunnyPass>().Destroy();
            }

            UpdateSens();
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
