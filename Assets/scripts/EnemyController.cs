using UnityEngine;
using System.Collections;
using UnityGameBase;

public class EnemyController : GameComponent<SpaceShooter> {
    public float Velocity;
    public GameObject Bomb;
    public float FireRate;
    private float nextFire;
    private float radiant;
    void OnEnable() {
        radiant = 2.0f;
        nextFire = Time.time + FireRate;
    }
	void Update () {
        float newposx = GetComponent<Rigidbody2D>().position.x;
        float newposy = GetComponent<Rigidbody2D>().position.y;
        float radius = 1.5f;
        radiant += (Velocity * Time.deltaTime / (2.0f * Mathf.PI));
        newposx = Mathf.Cos(radiant) * radius;
        newposy = Mathf.Sin(radiant) * radius;
        Vector2 position = new Vector2(newposx, newposy);
        GetComponent<Rigidbody2D>().position = position;
        if (Time.time > nextFire) {
            nextFire = Time.time + FireRate;
            GameObject bullet = Instantiate(Bomb, gameObject.transform.position, Quaternion.identity) as GameObject;
        }
	}
}
