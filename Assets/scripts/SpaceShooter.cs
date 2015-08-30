using UnityEngine;
using UnityGameBase;
using System.Collections;

public class SpaceShooter : Game {
    public GameObject Enemy;
    public GameObject Player;
    public int EnemyCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public int Score;
    public ushort Life;
    public UnityEngine.UI.Text Highscoretext;
    public UnityEngine.UI.Text Lifetext;
    public UnityEngine.UI.Text GameOverText;
    private bool gameover;
    #region implemented abstract members of Game
    protected override void Initialize () {
        //throw new System.NotImplementedException ();
        //UGB.Pool.CreateNewObjectPoolEntry();
        gameover = false;
        GameOverText.text = "";
        Score = 0;
        Life = 5;
        UpdateScore();
        UpdateLife();
        StartCoroutine(SpawnWaves());
    }
    protected override void GameSetupReady () {
        //throw new System.NotImplementedException ();
        Instantiate(Player);
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
            if (gameover)
                break;
        }
    }
    public void AddScore(int value) {
        Score += value;
        UpdateScore();
    }
    public void DecrementLife() {
        if (Life > 0) {
            Life--;
            Instantiate(Player);
        } else {
            GameOver();
        }
        UpdateLife();
    }
    public void UpdateScore() {
        Highscoretext.text = "Score: " + Score;
    }
    public void UpdateLife() {
        Lifetext.text = "Life x" + Life;
    }
    public void GameOver() {
        GameOverText.text = "Game Over!";
        gameover = true;
    }
}

