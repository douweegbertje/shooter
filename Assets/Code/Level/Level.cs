using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	private int levelWidth;
	private int levelHeight;

	public Transform grassTile;
	public Transform dirtTile;
	public Transform wallTile;
	//public GameObject enemyTile;
	public Entity Player;



	// Use this for initialization
	void Start () {
		levelWidth = 64;
		levelHeight = 64;
		LoadLevel();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log (collision.gameObject.tag);
		if(collision.gameObject.name == "enemy"){
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	
	}

	void LoadLevel()
	{
		for (int x = 0; x <levelWidth; x++) {
			for (int y = 0; y < levelHeight; y++) {
				if (x == 0 || y == 0 || x == levelWidth-1 || y == levelHeight-1) {
					createTile (x, y, wallTile);		
				} else {
					if (Random.Range(1,4) == 1) {
						createTile (x, y, dirtTile);
					} else {
						createTile (x, y, grassTile);
					}
				}
			}
		}

		//Instantiate (enemyTile, new Vector3 (11, 11), Quaternion.identity);
	}

	private void createTile(int x,int y,Transform Type) {
		Instantiate (Type, new Vector3 (x, y), Quaternion.identity);
	}
}
