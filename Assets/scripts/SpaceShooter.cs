using UnityEngine;
using UnityGameBase;
using System.Collections;

public class SpaceShooter : Game {
    public GameObject Enemy;
    public int EnemyCount;
    public float SpawnWait;
    public float StartWait;
    #region implemented abstract members of Game
    protected override void Initialize () {
        //throw new System.NotImplementedException ();
        //UGB.Pool.CreateNewObjectPoolEntry();
        StartCoroutine(SpawnWaves());
    }
    protected override void GameSetupReady () {
        //throw new System.NotImplementedException ();
    }
#endregion
    void Update(){
    }
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(StartWait);
        for (int i = 0; i < EnemyCount; i++) {
            Instantiate(Enemy);
            yield return new WaitForSeconds(SpawnWait);
        }
    }
}

