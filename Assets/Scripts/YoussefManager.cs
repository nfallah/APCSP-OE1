using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YoussefManager : MonoBehaviour
{
    [SerializeField] Sprite happy, angry;
    [SerializeField] GameObject face;

    public AudioSource soundtrack;

    public void ChangeState(int state)
    {
        switch (state)
        {
            case 0:
                face.GetComponent<SpriteRenderer>().sprite = happy;
                face.transform.localPosition = new Vector3(0, 0.425f, 0.05f);
                face.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                break;

            case 1:
                face.GetComponent<SpriteRenderer>().sprite = angry;
                face.transform.localPosition = new Vector3(0, 0.44f, -0.05f);
                face.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                break;
        }
    }

    public void PlayMusic()
    {
        soundtrack.Play();
    }
}   
