using UnityEngine;

public class CreatureBase : Interactable, IDamageable {

    [SerializeField] protected int maxHealthDefault;
    [SerializeField] [Range(0, 100)] protected int visionRadiusDefault = 16;
    protected int health;

    public virtual void Init() => CameraController.Main.Init(visionRadiusDefault);

    public virtual int TakeHit (int damage) {
        health = (health - damage) <= 0 ? 0 : health - damage;
        if (health == 0)
            Dead();
        else
            UIManager.Main.UpdateHealth(health);
        return health;
    }
    public virtual void Dead() { }
}
