﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc1Enemy : MonoBehaviour {

	public enum Mode{
		GoToA,
		GoToB,
		Attack
	}

	

	public Vector3 pointA;
	public Vector3 pointB;

	Vector3 my_pos;
	Vector3 rabit_pos;

	Mode mode = Mode.GoToA;

	Rigidbody2D myBody;
	Animator myController;

	

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		myController = this.GetComponent<Animator> ();
        my_pos = this.transform.position;
        rabit_pos = HeroRabit.lastRabit.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        my_pos = this.transform.position;
        rabit_pos = HeroRabit.lastRabit.transform.position;
    }

	void FixedUpdate(){
		updateMode ();
		float value = getDirection ();
		changeVilocity (value);
	}

	float getDirection(){
		if (mode == Mode.GoToA) {
			if (my_pos.x < pointA.x) {
				return 1;
			} else {
				return -1;
			}
		} else if (mode == Mode.GoToB) {
			if (my_pos.x < pointB.x) {
				return 1;
			} else {
				return -1;
			}
		} else if (mode == Mode.Attack) {
			if (my_pos.x < rabit_pos.x) {
				return 1;
			} else {
				return -1;
			}
		}
		return 0;
	}

	void changeVilocity(float value){
		Vector2 vel = myBody.velocity;
		vel.x = value;
		myBody.velocity = vel;
	}

	void updateMode(){
		if (rabit_pos.x > Mathf.Min (pointA.x, pointB.x) 
			&& rabit_pos.x < Mathf.Max (pointA.x, pointB.x)) {
			mode = Mode.Attack;
		} else if (mode == Mode.GoToA) {
			if (isArrived (pointA)) {
				mode = Mode.GoToB;
			}
		} else if (mode == Mode.GoToB) {
			if (isArrived (pointB)) {
				mode = Mode.GoToA;
			}
		}
	}

	bool isArrived(Vector3 point){
		return my_pos.x == point.x;
	}
}
