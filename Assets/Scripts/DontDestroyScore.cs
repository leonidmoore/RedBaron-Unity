using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScore : MonoBehaviour
{
    private static bool created = false;
    void Awake()
    {
        if (created == false)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
