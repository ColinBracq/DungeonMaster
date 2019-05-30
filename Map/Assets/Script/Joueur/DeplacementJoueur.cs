using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour {

	public static Vector2 Position;

	public float vitesseInitialee = 5f;
	private float vitesse;
	public float moveSmooth = .3f;

	private Rigidbody2D rb;

	Vector2 movement = Vector2.zero;
	Vector2 velocity = Vector2.zero;

	Vector2 mousePos = Vector2.zero;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        vitesse = vitesseInitialee ;
	}

	private void FixedUpdate()
	{
		

		Vector2 vitesseDesiree = movement * vitesse;
		rb.velocity = Vector2.SmoothDamp(rb.velocity, vitesseDesiree, ref velocity, moveSmooth);

		Vector2 directionRegardee = mousePos - rb.position;
		float angle = Mathf.Atan2(directionRegardee.y, directionRegardee.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;

		Position = rb.position;
	}

}
