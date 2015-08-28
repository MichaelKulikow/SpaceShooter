using UnityEngine;
using System.Collections;
using UnityGameBase;

public class DestroyByBoundary : GameComponent<SpaceShooter> {
    void OnTriggerExit2D(Collider2D other) {
        Destroy(other.gameObject);
        Debug.Log("destroyed");
    }
    //void OnTriggerStay2D(Collider2D other) {
    //    Debug.Log("stayed");
    //}
    //void OnTriggerEnter2D(Collider2D other) {
	//	Debug.Log("entered");
	//}
}
