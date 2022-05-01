using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject shooter;
	public GameObject explosionEffect;
	public LineRenderer lineRenderer;
	private Transform _firePoint;





	void Awake()
	{
		_firePoint = transform.Find("FirePoint");
	}

	// Start is called before the first frame update
	void Start()
    {
		// Invoke("Shoot", 1f);
		// Invoke("Shoot", 2f);
		// Invoke("Shoot", 3f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null && shooter != null) {
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

			Bullet bulletComponent = myBullet.GetComponent<Bullet>();

			if (shooter.transform.localScale.x < 0f) {
				// Left
				bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
			} else {
				// Right
				bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
			}
		}
	}

	public IEnumerator ShootWithRaycast(){
		if(explosionEffect != null && lineRenderer != null ){
			//

			RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);

			if (hitInfo){
				//example code
				// if (hitInfo.collider.tag == "Player"){
				// 	Transform player = hitInfo.transform;
				// 	player.GetComponent<PlayerHelth>().ApllyDamage(5);
				// }
				GameObject objt=hitInfo.collider.gameObject;

				Debug.Log(objt.name);

				Debug.Log(hitInfo.collider.tag);
				//Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);
				lineRenderer.SetPosition(0, _firePoint.position);
				lineRenderer.SetPosition(1, hitInfo.point);
				GameObject instantiatedObject = Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);
				Destroy(instantiatedObject, 2f);


            }
            else{
				Debug.Log("Se fue la bala");
				lineRenderer.SetPosition(0, _firePoint.position);
				lineRenderer.SetPosition(1, hitInfo.point + Vector2.right * 100);
			}
			lineRenderer.enabled = true;

			yield return null;

			lineRenderer.enabled = false;
			
		}
	}

}
