using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {

    public static GameManager Main = null;

    public bool startedGame;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    void Update() {
        if (Keyboard.current.anyKey.wasPressedThisFrame && !startedGame) {
            InitGame();
            startedGame = true;
        }
    }

    void InitGame() {
        CreatureManager.Main.Init();
        CreaturePlayable.Main.Init();
        UIManager.Main.InitGame();
        print("Game Init");
    }

}
