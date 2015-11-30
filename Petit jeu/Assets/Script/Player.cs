using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int _Life;
	private bool _Shooting = false;
	private int _Damage;
	private bool _Jumping = false;
	private Transform _T;
	private bool _Side = true;
	private GameObject _Sprite;
	private Animator _Anim;
	private Rigidbody2D _Rb;

	public Player(int life,int damage, Transform t, GameObject sprite, Animator anim, Rigidbody2D rb) {
		this._Life = life;
		this._Damage = damage;
		this._T = t;
		this._Sprite = sprite;
		this._Anim = anim;
		this._Rb = rb;
	}

	public void playerMoving(float axisH) {
		this._Anim.SetFloat ("Speed", Mathf.Abs(axisH));
		this._T.Translate (Vector3.right * axisH * Time.deltaTime);
		if (axisH > 0.1f)
		{
			this._Sprite.transform.eulerAngles = new Vector3(0, 0, 0);
		} 
		else if (axisH < -0.1f)
		{
			this._Sprite.transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}
	public void playerJumping(float jumpForce) {
		this._Anim.SetBool ("Jumping", true);
		this._Rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	public void playerShooting() {
		this._Anim.SetBool ("Shooting", true);

	}
}
