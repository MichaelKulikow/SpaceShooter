using UnityEngine;
using System.Collections;
using UnityGameBase;

public class Mover : GameComponent<SpaceShooter> {
    public float Speed;
    private Vector3 target;
    void Start() {
        target = GetComponent<Transform>().position;
        if (gameObject.tag == "Bolt")
            target *= -1.0f;
    }
    void Update() {
        GetComponent<Rigidbody2D>().velocity = target * Speed;
    }
}
