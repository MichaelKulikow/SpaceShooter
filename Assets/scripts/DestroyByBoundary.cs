using UnityEngine;
using System.Collections;
using UnityGameBase;

public class DestroyByBoundary : GameComponent<SpaceShooter> {
    void OnTriggerExit2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
