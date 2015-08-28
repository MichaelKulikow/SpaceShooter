using UnityEngine;
using System.Collections;
using UnityGameBase;

public class DestroyByContact : GameComponent<SpaceShooter> {
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.name == "Background" || other.name == "Enemy" || other.name == "Bomb(Clone)") {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
