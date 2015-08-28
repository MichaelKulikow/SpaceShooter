using UnityEngine;
using UnityGameBase;

public class SpaceShooter : Game
{
    public GameObject star;
    #region implemented abstract members of Game

    protected override void Initialize ()
    {
        //throw new System.NotImplementedException ();
        //UGB.Pool.CreateNewObjectPoolEntry();
    }

    protected override void GameSetupReady ()
    {
        //throw new System.NotImplementedException ();
    }

#endregion
    void Update(){
      //  Instantiate(star);
    }
}

