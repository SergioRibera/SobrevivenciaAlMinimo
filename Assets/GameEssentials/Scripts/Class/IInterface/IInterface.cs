public interface IComestible {
    bool Consume(TypeAlimentation typeAlimentation);
}

public interface ICreaturePart {
    CreaturePart CreaturePart { set; get; }
    void Action(CreatureBase me, CreatureBase other);
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
