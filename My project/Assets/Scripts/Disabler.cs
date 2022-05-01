using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    //private PlayerHealth _playerHealth; 
    private void OnTriggerEnter2D(Collider2D collision){
        
        // if(collision.tag == "Player"){
        // GameObject player = collision.gameObject;
        // _playerHealth = GetComponent<PlayerHealth>();
        // _playerHealth.Recovery();
        // }
        
        // Debug.Log(collision.tag);
        // GameObject enemy = collision.gameObject.transform.GetChild(1).gameObject;
        
        collision.gameObject.SetActive(false);
        // enemy.SetActive(true);
        
    }

}
