using UnityEngine;
using Random = UnityEngine.Random;

public class TypeAlimentationBehaviour : MonoBehaviour, IComestible {
    public TypeAlimentation typeAlimentation;

    public bool Consume(TypeAlimentation typeAlimentation) {
        if (this.typeAlimentation == typeAlimentation || typeAlimentation == TypeAlimentation.Omnivore) {
            DataManager.CurrentNutrition += Random.Range(2, 10);
            float nextStep = 1.0f / DataManager.MaxNutrition * DataManager.CurrentNutrition;
            LeanTween.value(UIManager.Main.nutritionPoint.fillAmount, nextStep, 1f).setOnUpdate((float v) => {
                if (DataManager.Level != (DataManager.Level + 1))
                    UIManager.Main.UpdateNutritionPoint(v);
            });
            GameObject.Destroy(gameObject);
            if (DataManager.CurrentNutrition >= DataManager.MaxNutrition) {
                DataManager.CurrentNutrition = 0;
                CreaturePlayable.Main.NextLevel();
            }
            return true;
        }
        return false;
    }
}
