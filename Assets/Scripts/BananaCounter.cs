using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaCounter : MonoBehaviour
{
    public int bananas;
    public int currentBananas;

    public Text bananaText;

    private void Awake()
    {
        currentBananas = 0;

        BananaProperties[] _bananas  = (BananaProperties[])GameObject.FindObjectsOfType(typeof(BananaProperties));
        bananas = _bananas.Length;

        bananaText.text = currentBananas + " / " + bananas + " BANANAS";
    }

    public void UpdateBananas()
    {
        currentBananas += 1;
        bananaText.text = currentBananas + " / " + bananas + " BANANAS";

        if (currentBananas == bananas)
        {
            GetComponent<Main>().VictoryCondition();
        }
    }
}
