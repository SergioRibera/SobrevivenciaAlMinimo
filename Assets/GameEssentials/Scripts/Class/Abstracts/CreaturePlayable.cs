using System.Collections.Generic;
using UnityEngine;

public class CreaturePlayable : CreatureBase {

    [SerializeField] float creatureSpeed; 

    IInput[] inputs;
    IInput inputSelected;
    List<ICreaturePart> parts;

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
        // TODO: Load Parts
        parts = new List<ICreaturePart>();
        Test();
    }

    void Test() {
        parts.Add(new Eye(){
            CreaturePart = new CreaturePart(Vector3.zero, null),
            visionHability = 4f
        });
    }

    public override void Init() {
        base.Init();
        inputSelected?.Init();
        foreach (var part in parts)
            part.Init();
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
