using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    private CircleCollider2D _circleCollider2d;
    private SpriteRenderer _renderer;



    void Awake()
	{

		_circleCollider2d = GetComponent<CircleCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();


	}

    public void AddDamage(){
        
        //Visual Feedback
        StartCoroutine("VisualFeedback");
        _circleCollider2d.isTrigger=true;
        // gameObject.SetActive(false);
        
    }

    private IEnumerator VisualFeedback(){

        _renderer.color = Color.red;
         yield return new WaitForSeconds(0.7f);

         _renderer.color = Color.white;
    }



}
