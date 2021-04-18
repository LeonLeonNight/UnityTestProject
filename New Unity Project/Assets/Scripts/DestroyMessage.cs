using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMessage : MonoBehaviour
{
    public float time =2;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, time);
    }
}
