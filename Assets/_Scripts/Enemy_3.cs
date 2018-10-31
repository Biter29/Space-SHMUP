using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy {

    [Header("Set in Inspector: Enemy_3")]
    public float lifeTime = 5;

    [Header("Set Dynamically: Enemy_3")]
    public Vector3[] points;
    public float birthTime;
    // Use this for initialization
    void Start () {
        points = new Vector3[3];
        points[0] = pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
