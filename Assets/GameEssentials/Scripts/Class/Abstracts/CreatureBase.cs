using UnityEngine;

public class CreatureBase : Interactable, IDamageable {

    [SerializeField] protected int maxHealthDefault;
    [SerializeField] protected float visionRadiusDefault = .16f;
    protected int health;

    public virtual void Init() {
        CameraController.Main.ChangeVision(visionRadiusDefault);
        CameraController.Main.CanAnimateVision(true);
    }

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
