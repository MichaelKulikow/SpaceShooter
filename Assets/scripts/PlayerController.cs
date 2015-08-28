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
        //UGB.Input.KeyMappingTriggered += KeyDown;
		//UGB.Input.KeyDown += KeyDown;
        UGB.Input.TapEvent += Tap;
        worldradiant = 1.5f * Mathf.PI;
        localradiant = 0.0f;
	}
	void OnDisable() {
		UGB.Input.SwipeEvent -= OnSwipe;
        //UGB.Input.KeyMappingTriggered -= KeyDown;
		//UGB.Input.KeyDown -= KeyDown;
        UGB.Input.TapEvent -= Tap;
	}
	void OnSwipe(TouchInformation touchInfo) {
        horizontal = touchInfo.GetHorizontalAxis();
        //Debug.Log("Distance: " + touchInfo.distance.ToString());
		//switch (touchInfo.GetSwipeDirection()) {
		//	case TouchInformation.ESwipeDirection.Left:
		//		Debug.Log("Left Swipe");
		//		break;
		//	case TouchInformation.ESwipeDirection.Right:
		//		Debug.Log("Right Swipe");
		//		break;
		//}
	}
    void Tap(TouchInformation touchInfo) {
        //Debug.Log("Tap");
        if (Time.time > nextFire) {
            nextFire = Time.time + FireRate;
            GameObject bullet = Instantiate(Shot, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
            Destroy(bullet, 0.2f);
        }
    }
    //void KeyDown(string keyMapping) {
    //    Debug.Log("KeyDown");	  
	//}
    void Update() {
       //if (Input.GetButton("Fire1") && Time.time > nextFire) {
       //     nextFire = Time.time + fireRate;
       //     GameObject bullet = Instantiate(shot, GetComponent<Transform>().position, Quaternion.identity) as GameObject;
       //     Destroy(bullet, 0.2f);
       //}
    }
    void FixedUpdate() {
        //horizontal = Input.GetAxis("Horizontal");
        //fire = Input.GetButton("Fire1");
        Move();
        horizontal = 0.0f;
        //if (fire)
        //    Debug.Log("Fire");
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
