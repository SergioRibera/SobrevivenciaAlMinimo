using UnityEngine;

public interface IComestible {
    bool Consume(TypeAlimentation typeAlimentation);
}

public interface ICreaturePart {
    CreaturePart CreaturePart { set; get; }
    void Init();
    TypePart GetTypePart { get; }
    void ActionEnter(string tag, CreatureBase me, GameObject other);
    void ActionStay(string tag, CreatureBase me, GameObject other);
    void ActionExit(string tag, CreatureBase me, GameObject other);
}

public interface IDamageable {
    ///
    ///<summary>This return rest of the life after damaged</summary>
    ///
    int TakeHit(int damage);
}

public interface IInput {
    void Init();
    void Update();
    void Stop();
}
