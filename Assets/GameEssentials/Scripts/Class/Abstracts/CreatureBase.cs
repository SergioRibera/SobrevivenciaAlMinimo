using UnityEngine;

public class CreatureBase : Interactable, IDamageable {

    [SerializeField] int maxHealthDefault;
    int health;

    void Start() {
        DataManager.Init();
        if (DataManager.DataLoaded) {
            health = DataManager.Health;
        } else {
            health = maxHealthDefault;
        }
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
