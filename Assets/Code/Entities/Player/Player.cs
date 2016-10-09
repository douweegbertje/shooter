using UnityEngine;
using System.Collections;

public class Player : Entity {

	public GameObject bulletPrefab;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
			direction = 1;
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
			direction = 0;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
			direction = 2;
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
			direction = 3;
		}
	}


	void Fire()
	{
		var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
		position = Camera.main.ScreenToWorldPoint(position);
		var go = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
		go.transform.LookAt(position);       
		go.GetComponent<Rigidbody2D>().AddForce(go.transform.forward * 5000);
	}	

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log (collision.gameObject.tag);
		if(collision.gameObject.name == "enemy"){
			Destroy(this.gameObject);
		}
	}
}
