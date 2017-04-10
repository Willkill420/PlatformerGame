using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaEnemy : MovingObject {
	
	public float timeInSeconds = 2f;
	public Vector2 firstPos;
	public Vector2 lastPos;

	private bool flip;
	private float time;
	private Vector2 start;
	private Vector2 end;

	void Start() {
		base.gravity = 0f;
		SetDest(firstPos, lastPos);
		flip = true;
	}

	void Update() {
		
	}
	
	public override void FixedUpdateMovement() {
		velocity = Vector2.zero;
		if(transform.position.x == end.x && transform.position.y == end.y) {
			if(flip) SetDest(lastPos, firstPos);
			else SetDest(firstPos, lastPos);
			flip = !flip;
		}
		time += Time.deltaTime / (timeInSeconds - 1);
		transform.position = Vector2.Lerp(start, end, time);
		base.FixedUpdateMovement();
	}

	public void SetDest(Vector2 origin, Vector2 dest) {
		time = 0f;
		start = origin;
		end = dest;
	}
}
