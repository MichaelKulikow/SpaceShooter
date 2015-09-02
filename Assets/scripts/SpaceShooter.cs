using UnityEngine;
using UnityGameBase;
using System.Collections;

public class SpaceShooter : Game {
    public enum Objecttype{
        player,
        enemy,
        bomb,
        explosion
    }
    public GameObject Enemy;
    public GameObject Player;
    public GameObject Bomb;
    public GameObject Explosion;
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
        gameover = false;
        GameOverText.text = "";
        Score = 0;
        Life = 5;
        UpdateScore();
        UpdateLife();
        StartCoroutine(SpawnWaves());
    }
    protected override void GameSetupReady () {
        UGB.Pool.CreateNewObjectPoolEntry(Player, (int)SpaceShooter.Objecttype.player, 1);
        UGB.Pool.CreateNewObjectPoolEntry(Enemy, (int)SpaceShooter.Objecttype.enemy, 1);
        UGB.Pool.CreateNewObjectPoolEntry(Bomb, (int)SpaceShooter.Objecttype.bomb, 1);
        UGB.Pool.CreateNewObjectPoolEntry(Explosion, (int)SpaceShooter.Objecttype.explosion, 1);
        UGB.Pool.GetInstance((int)SpaceShooter.Objecttype.player);
    }
#endregion
    void Update(){
    }
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(StartWait);
        while (true) {
            for (int i = 0; i < EnemyCount; i++) {
                UGB.Pool.GetInstance((int)SpaceShooter.Objecttype.enemy);
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
            if(Life == 0) 
                GameOver();
            else
                Instantiate(Player);
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

