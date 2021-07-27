using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyPass : MonoBehaviour
{
    public float sens;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
