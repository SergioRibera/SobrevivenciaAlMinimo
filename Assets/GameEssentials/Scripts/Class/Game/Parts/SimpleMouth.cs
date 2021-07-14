using System;
using UnityEngine;

public class SimpleMouth : MonoBehaviour, ICreaturePart {
    [SerializeField] CreaturePart _creatureParts;

    public CreaturePart CreaturePart { get => _creatureParts; set => _creatureParts = value; }

    public void Action(CreatureBase me, CreatureBase other) {
        throw new NotImplementedException();
    }

    public void Init() {
        throw new NotImplementedException();
    }
}
