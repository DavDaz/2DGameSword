using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRetry : MonoBehaviour
{
    public GameObject player;

    public void Retry()
    {
        player.transform.position = this.transform.position;
        
    }
}
