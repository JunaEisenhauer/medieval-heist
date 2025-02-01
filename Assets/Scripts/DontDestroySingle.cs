using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySingle : MonoBehaviour
{
    private static DontDestroySingle instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
