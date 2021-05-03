using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    /// <summary>
    /// https://scholarslab.lib.virginia.edu/blog/teleporting-in-Unity3D/
    /// </summary>
     

    public Transform teleportTarget;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
