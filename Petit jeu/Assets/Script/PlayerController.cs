using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Player pl;
	public int life = 100;
	public Transform arrowPrefab;
	public Transform hand;
	public float speed = 5;
	public int damage = 10;
	public float jumpForce = 5;
	public bool lookRight = true;
	public float arrowDelay=0.4f;
	public GameObject sprite;

	// Use this for initialization
	void Start () {
		pl = new Player (life, damage, transform, sprite, sprite.GetComponent<Animator>(), GetComponent<Rigidbody2D>()); 
	}

	IEnumerator makeArrow(float delay, bool right)
	{
		yield return new WaitForSeconds(delay);
		var go = Instantiate(arrowPrefab, hand.position, Quaternion.identity) as Transform;
		go.GetComponent<Arrow>().right = right;
	}
	
	// Update is called once per frame
	void Update () 
	{
		int layermask;
		layermask = ~(1 << LayerMask.NameToLayer ("player"));;
		sprite.GetComponent<Animator>().SetBool("Jumping", false);
		sprite.GetComponent<Animator>().SetBool("Shooting", false);
		pl.playerMoving (Input.GetAxis ("Horizontal") * speed);
		if (sprite.transform.rotation.eulerAngles.y >= 1)
			lookRight = false;
		else
			lookRight = true;
		if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(transform.position, -Vector2.up, 2, layermask)) 
		{
			//Debug.Log (Physics2D.Raycast(transform.position, -Vector2.up, 1, layermask).transform.position);
			Debug.Log ("TOTO");
			pl.playerJumping (jumpForce);
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			pl.playerShooting();
			StartCoroutine(makeArrow(arrowDelay, lookRight));
		}
	}
}
