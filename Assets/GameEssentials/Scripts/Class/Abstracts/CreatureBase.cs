using UnityEngine;

public class CreatureBase : Interactable, IDamageable {

    [SerializeField] public int maxHealthDefault;
    [SerializeField] [Range(0, 100)] public int visionRadiusDefault = 16;
    public int health;

    internal bool isDead {
        get => health <= 0;
    }

    public virtual void Init() => CameraController.Main.Init(visionRadiusDefault);

    public virtual int TakeHit (int damage) {
        if (isDead)
            return 0;
        health = (health - damage) <= 0 ? 0 : health - damage;
        if (health == 0)
            Dead();
        UIManager.Main.UpdateHealth(1.0f / (float) maxHealthDefault * (float) health);
        return health;
    }
    public virtual void Dead() { }
}
