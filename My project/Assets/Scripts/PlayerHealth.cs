using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;
    public RectTransform heartUI;
    //Game Over
    public RectTransform gameOverMenu;
    public GameObject hordes;

    public ParticleSystem explosion;
    private int health;
    private float heartSize = 16f;
    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;
    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
        
        
    }

    public void AddDamage(int amount){
        health = health - amount;

        //Visual Feedback
        explosion.Emit(1);
        //explosion.Play();
        StartCoroutine("VisualFeedback");
        

        // Game Over
        if(health <= 0){
            health = 0;
            gameObject.SetActive(false);
            Recovery();
        }
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize );
        Debug.Log("Player got damaged. His current health is "+ health);
    }

    public void AddHealth(int amount){
        health = health + amount;

        //Max health
        if (health > totalHealth){
            health = totalHealth;
        }
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize );
        Debug.Log("Player got some life. His current health is "+ health);

    }
    public void Recovery(){
            health = totalHealth;
            heartUI.sizeDelta = new Vector2(heartSize * health, heartSize );
            _renderer.color = Color.white;

    }

    private IEnumerator VisualFeedback(){
        _renderer.color = Color.red;
         yield return new WaitForSeconds(0.1f);

         _renderer.color = Color.white;
    }

    private void OnEnable(){
        health = totalHealth;

    }

    private void OnDisable()
    {
        gameOverMenu.gameObject.SetActive(true);

        hordes.SetActive(false);
        _animator.enabled = false;
        _controller.enabled = false;
    }

}
