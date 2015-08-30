using UnityEngine;
using System.Collections;
using UnityGameBase;

public class DestroyByContact : GameComponent<SpaceShooter> {
    public GameObject Explosion;
    public GameObject PlayerExplosion;
    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.name);
        GameObject exp, pexp;
        if (other.tag == "Background" || other.tag == "Enemy" || other.tag == "Bomb") {
            return;
        }
        exp = Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        if (other.tag == "Player") {
            pexp = Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(pexp, 1.0f);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(exp, 1.0f);
    }
}
