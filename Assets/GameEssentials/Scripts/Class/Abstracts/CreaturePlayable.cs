using UnityEngine;

public class CreaturePlayable : CreatureBase {

    [SerializeField] float creatureSpeed; 

    IInput[] inputs;
    IInput inputSelected;

    public static CreaturePlayable Main = null;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        /* DataManager.Init(); */
        /* if (DataManager.DataLoaded) { */
        /*     health = DataManager.Health; */
        /* } else { */
        /*     health = maxHealthDefault; */
        /* } */
        inputs = new IInput[] {
            new NormalDetection(GetComponent<Rigidbody2D>(), creatureSpeed),
            new KeyboardDetection(transform)
        };
        /* inputSelected = inputs[DataManager.IndexInputSelected]; */
        inputSelected = inputs[0];
    }

    public override void Init() {
        base.Init();
        inputSelected?.Init();
    }

    void FixedUpdate() => inputSelected?.Update();
}
