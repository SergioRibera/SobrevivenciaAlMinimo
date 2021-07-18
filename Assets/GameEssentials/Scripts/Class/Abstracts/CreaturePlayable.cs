using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePlayable : CreatureBase {

    [SerializeField] float creatureSpeed; 

    IInput[] inputs;
    IInput inputSelected;
    List<ICreaturePart> parts;

    List<Action> levelsActions;

    public static CreaturePlayable Main = null;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        DataManager.Init();
        if (DataManager.DataLoaded) {
            health = DataManager.Health;
        } else {
            health = maxHealthDefault;
        }
        inputs = new IInput[] {
            new NormalDetection(GetComponent<Rigidbody2D>(), creatureSpeed),
            new KeyboardDetection(transform)
        };
        inputSelected = inputs[DataManager.IndexInputSelected];
        levelsActions = new List<Action>() {
            () => StartCoroutine(Level0()),
            Level1,
            Level2,
            Level3,
            Level4,
            Level5
        };
        // TODO: Load Parts
        parts = new List<ICreaturePart>();
        Test();
    }

    void Test() {
        parts.Add(new Eye(){
            CreaturePart = new CreaturePart(Vector3.zero, null),
            visionHability = 60
        });
    }

    public override void Init() {
        base.Init();
        inputSelected?.Init();
        foreach (var part in parts)
            part.Init();
        levelsActions[DataManager.Level]();
    }
    IEnumerator Level0() {
        int timeDuration = 30,
              time = 0;
        while (time < timeDuration) {
            yield return new WaitForSeconds(1);
            time++;
        }
        NextLevel();
    }
    void Level1() { print("Level 1"); }
    void Level2() {}
    void Level3() {}
    void Level4() {}
    void Level5() {}

    void NextLevel() {
        // TODO: Add efect
        DataManager.Level++;
        levelsActions[DataManager.Level]();
    }
    void FixedUpdate() => inputSelected?.Update();

    public override void TriggerEnter2D(string tag, GameObject go) {
        foreach (var part in parts) {
            if (tag == "Alimento" && part.GetTypePart == TypePart.Mouth)
                part.Action(this, go);
            // TODO: Fill all
        }
    }
}
