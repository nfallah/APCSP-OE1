using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPosition : MonoBehaviour
{

    public Transform test;
    [SerializeField] float yLock;

    private void Update()
    {
        Vector3 position = test.position;
        position.y = yLock;
        test.position = position;
        Vector3 lol = test.position;
        print(lol);
    }
}
