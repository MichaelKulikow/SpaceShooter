using UnityEngine;
using UnityGameBase;
using System.Collections;

public class SpaceShooter : Game {
    public GameObject Enemy;
    public int EnemyCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public int Score;
    public UnityEngine.UI.Text Highscoretext;
    #region implemented abstract members of Game
    protected override void Initialize () {
        //throw new System.NotImplementedException ();
        //UGB.Pool.CreateNewObjectPoolEntry();
        Score = 0;
        UpdateScore();
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
        while (true) {
            for (int i = 0; i < EnemyCount; i++) {
                Instantiate(Enemy);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
        }
    }

    public void AddScore(int value) {
        Score += value;
        UpdateScore();
    }
    void UpdateScore() {
        Highscoretext.text = "Score: " + Score;
    }
}

