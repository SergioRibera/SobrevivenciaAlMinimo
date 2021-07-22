using UnityEngine;

public class SimpleMouth : ICreaturePart {
    CreaturePart _creatureParts;

    public CreaturePart CreaturePart { get => _creatureParts; set => _creatureParts = value; }

    public TypePart GetTypePart => TypePart.Mouth;

    public void Action(CreatureBase me, CreatureBase other) { }

    public void Action(CreatureBase me) { }

    public void Action(CreatureBase me, GameObject go) {
        // TODO: Animate
        GameObject.Destroy(go);
        DataManager.CurrentNutrition ++;
        float nextStep = 1.0f / DataManager.MaxNutrition * DataManager.CurrentNutrition;
        LeanTween.value(UIManager.Main.nutritionPoint.fillAmount, nextStep, 1f).setOnUpdate((float v) => {
            if (DataManager.Level != (DataManager.Level + 1))
                UIManager.Main.UpdateNutritionPoint(v);
        });
    }

    public void Init() { }
}
