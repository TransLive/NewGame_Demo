using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonManager<GameManager> , IMessageShow
{
    public Player player= null;

    protected override void Awake()
    {
        base.Awake();
    }

    void start()
    {
        player = new Player();
    }
}
