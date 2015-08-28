using UnityEngine;
using System.Collections;
using UnityGameBase;

public class StarMover : GameComponent<SpaceShooter> {
    public float Speed;
    private Vector3 direction;
	void Start () {
        direction = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0.0f);
	}
	void Update () {
        GetComponent<Rigidbody2D>().velocity = direction * Speed;
        GetComponent<Transform>().localScale *= 1.002f;
	}
}
