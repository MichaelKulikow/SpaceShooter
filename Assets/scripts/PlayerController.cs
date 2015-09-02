using UnityEngine;
using System.Collections;
using UnityGameBase;

public class PlayerController : GameComponent<SpaceShooter> {
    private float worldradiant;
    private float localradiant;
    private float horizontal;
    private float nextFire;
    private bool fire;
    public float Velocity;
    public GameObject Shot;
    public float FireRate;
	void OnEnable() {
		UGB.Input.SwipeEvent += OnSwipe;
        UGB.Input.TapEvent += Tap;
        UGB.Input.KeyDown += KeyDown;
        worldradiant = 1.5f * Mathf.PI;
        localradiant = 0.0f;
	}
	void OnDisable() {
		UGB.Input.SwipeEvent -= OnSwipe;
        UGB.Input.TapEvent -= Tap;
        UGB.Input.KeyDown -= KeyDown;
	}
    void KeyDown(string Key) {
        if (Key == "InputLeft") {
            Debug.Log("LEFT");
        }    
    }
	void OnSwipe(TouchInformation touchInfo) {
        horizontal = touchInfo.GetHorizontalAxis();
	}
    void Tap(TouchInformation touchInfo) {
        if (Time.time > nextFire) {
            nextFire = Time.time + FireRate;
            GameObject bullet = Instantiate(Shot, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
            Destroy(bullet, 0.2f);
        }
    }
    void FixedUpdate() {
        Move();
    }
    void Move() {
        float newposx = GetComponent<Rigidbody2D>().position.x;
        float newposy = GetComponent<Rigidbody2D>().position.y;
        float radius = 4.3f;
        float multiplier = (Velocity * Time.deltaTime / (2.0f * Mathf.PI));
        worldradiant += horizontal * multiplier;
        localradiant += horizontal * multiplier;
        newposx = Mathf.Cos(worldradiant) * radius;
        newposy = Mathf.Sin(worldradiant) * radius;
        Vector2 position = new Vector2(newposx, newposy);
        GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 0.0f, localradiant * Mathf.Rad2Deg);
        GetComponent<Rigidbody2D>().position = position;
    }
}
