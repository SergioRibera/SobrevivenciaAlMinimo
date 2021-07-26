using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {

    public Vector2 sizeBound;
    public Vector2 timeRnd;

    public GameObject[] prefabsAlimentation;

    public static GameManager Main = null;

    public bool startedGame { get; private set; }
    public bool pausedGame = true;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    IEnumerator Start() {
        while (true) {
            float t = Random.Range(timeRnd.x, timeRnd.y);
            yield return new WaitForSeconds(t);
            GameObject go = Instantiate(prefabsAlimentation[Random.Range(0, prefabsAlimentation.Length)]);
            go.tag = "Alimento";
            Vector3 pos = new Vector3(Random.Range(-sizeBound.x, sizeBound.x), Random.Range(-sizeBound.y, sizeBound.y), .2f);
            go.transform.position = pos;
        }
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
        startedGame = true;
        pausedGame = !pausedGame;
    }

    public void TogglePuse() {
        pausedGame = !pausedGame;
        UIManager.Main.ToglePauseMenu(pausedGame);
    }

    public void QuitGame() => Application.Quit();

}
