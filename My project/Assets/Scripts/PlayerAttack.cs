using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Text pointUI;
    private bool _isAttacking;
    private Animator _animator;
    private int points = 0;
    private string score; 

    private void Awake(){
        _animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
            _isAttacking = true;
        }else{
            _isAttacking = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttacking == true){
            if (collision.CompareTag("Enemy") || collision.CompareTag("Big Bullet")){
                collision.SendMessageUpwards("AddDamage");
                Debug.Log(AddPoint());
                pointUI.text = AddPoint();
                
            }
        }
    }

    private string AddPoint(){
        points = points + 1;
        score = points.ToString();
        return score;
    }

    public void ResetScore(){
        points = 0;
        pointUI.text = "0";
    }


}
