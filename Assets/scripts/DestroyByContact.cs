using UnityEngine;
using System.Collections;
using UnityGameBase;

public class DestroyByContact : GameComponent<SpaceShooter> {
    public int ScoreValue;
    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.name);
        GameObject exp, pexp;
        if (other.tag == "Background" || other.tag == "Enemy" || other.tag == "Bomb") {
            return;
        }
        exp = UGB.Pool.GetInstance((int)SpaceShooter.Objecttype.explosion);
        exp.transform.position = gameObject.transform.position;
        exp.transform.rotation = gameObject.transform.rotation;
        if (other.tag == "Player") {
            pexp = UGB.Pool.GetInstance((int)SpaceShooter.Objecttype.explosion);
            pexp.transform.position = other.transform.position;
            pexp.transform.rotation = other.transform.rotation;
            Destroy(pexp, 1.0f);
            UGB.GetGame<SpaceShooter>().DecrementLife();
        }
        UGB.GetGame<SpaceShooter>().AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(exp, 1.0f);
    }
}
