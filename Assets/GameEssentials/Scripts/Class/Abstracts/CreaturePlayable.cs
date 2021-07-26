using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class CreaturePlayable : CreatureBase {

    [SerializeField] float creatureSpeed; 

    IInput[] inputs;
    IInput inputSelected;
    List<ICreaturePart> parts;

    List<Action> levelsActions;

    public static CreaturePlayable Main = null;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
        DataManager.Init();
    }

    void Start() {
        if (DataManager.DataLoaded) {
            maxHealthDefault = DataManager.Health;
            if (DataManager.IsNewData) {
                // TODO: Load defaults
                parts = new List<ICreaturePart>();
            }
        }
        health = maxHealthDefault;
        inputs = new IInput[] {
            new NormalDetection(GetComponent<Rigidbody2D>(), creatureSpeed),
            new KeyboardDetection(transform)
        };
        inputSelected = inputs[DataManager.IndexInputSelected];
        levelsActions = new List<Action>() {
            () => StartCoroutine(Level0()),
            Level1,
            () => DataManager.MaxADN = 8,
            () => DataManager.MaxADN = 10,
            () => DataManager.MaxADN = 12,
            () => DataManager.MaxADN = 15
        };
        CalculateNextMaxNut();
    }

    public bool ContainsPart(ICreaturePart part) => parts.Contains(part);
    public int ContainsPart(TypePart typePart) => parts.FindAll(p => p.GetTypePart == typePart).Count;

    GameObject goPart;
    public bool AddCreaturePart(ICreaturePart part, bool save = true) {
        // TODO: Verification
        if ((DataManager.ADN + part.CreaturePart.adnValue) > DataManager.MaxADN) {
            UIManager.Main.ShowNotification("No tienes puntos de ADN disponibles", 3f, $"Imposible Agregar la pieza");
            return false;
        }
        parts.Add(part);
        if (save)
            DataManager.AddCreaturePart(part.CreaturePart.name);
        DataManager.ADN += part.CreaturePart.adnValue;
        goPart = new GameObject(part.GetTypePart.ToString() + part.CreaturePart.name);
        goPart.transform.rotation = transform.rotation;
        goPart.transform.SetParent(transform);
        goPart.AddComponent<SpriteRenderer>().sprite = part.CreaturePart.img;
        goPart.transform.localPosition = part.CreaturePart.pos;
        goPart.transform.localScale = part.CreaturePart.scale;
        if (part.CreaturePart.collisionSize != 0f) {
            var cc = goPart.AddComponent<CircleCollider2D>();
            goPart.AddComponent<PartBehaviour>().Init(part, this);
            cc.radius = part.CreaturePart.collisionSize;
            cc.isTrigger = true;
        }
        part.Init();
        UIManager.Main.UpdateADNPoint();
        return true;
    }

    public void RemovePart(ICreaturePart part) {
        var p = transform.Find(part.GetTypePart.ToString() + part.CreaturePart.name);
        if (p != null)
            Destroy(p.gameObject);
        if (part.GetTypePart == TypePart.Vision) {
            int cPart = ContainsPart(part.GetTypePart);
            if (cPart > 1) {
                int sumParts = parts.Sum(i => i.CreaturePart.value) - part.CreaturePart.value;
                CameraController.Main.Init(sumParts);
            } else
                CameraController.Main.Init(visionRadiusDefault);
        }
        DataManager.ADN -= part.CreaturePart.adnValue;
        UIManager.Main.UpdateADNPoint();
        parts.Remove(part);
    }

    public override void Init() {
        base.Init();
        inputSelected?.Init();
        UIManager.Main.UpdateHealth(1.0f / maxHealthDefault * health);
        UIManager.Main.UpdateADNPoint();
        if (DataManager.Level >= 1)
            UIManager.Main.EnableInteractable();
        foreach (var part in parts)
            part.Init();
        NextLevel();
    }
    int anim0ID;
    IEnumerator Level0() {
        int timeDuration = 30,
              time = 0;
        UIManager.Main.ShowNotification("Sobrevive esta primera etapa! Haz click para moverte", 4f, title: "Bienvenido al mundo!!!!");
        while (time < timeDuration) {
            yield return new WaitForSeconds(1);
            float nextStep = 1.0f / timeDuration * time;
            anim0ID = LeanTween.value(UIManager.Main.nutritionPoint.fillAmount, nextStep, 1f).setOnUpdate((float v) => {
                if (DataManager.Level != (DataManager.Level + 1))
                    UIManager.Main.UpdateNutritionPoint(v);
            }).id;
            time++;
        }
        LeanTween.cancel(anim0ID);
        NextLevel();
    }
    void Level1() {
        UIManager.Main.EnableInteractable();
        print("Level 1");
    }

    void CalculateNextMaxNut() => DataManager.MaxNutrition = DataManager.Level * 10 + (Random.Range(2, 30));
    public void NextLevel() {
        // TODO: Add effect
        DataManager.Level++;
        CalculateNextMaxNut();
        levelsActions[DataManager.Level]();
        UIManager.Main.UpdateLevel();
        if (DataManager.Level > 0) {
            CreatureManager.Main.UnlockPlayerLevel();
            UIManager.Main.UpdateADNPoint();
            UIManager.Main.ShowNotification("Haz desbloquado nuevas partes! Haz click en la burbuja para ver mas informacion", 5f, title: "Una nueva etapa!!!!");
        }
    }
    void FixedUpdate() {
        if (isDead || GameManager.Main.pausedGame) return;
        inputSelected?.Update();
    }

    public override int TakeHit(int damage) {
        // TODO: Animate
        // TODO: Add Repulsion
        int res = base.TakeHit(damage);
        DataManager.Health = health;
        return res;
    }

    [ContextMenu("Take Damage")]
    public void Damage() {
        TakeHit(10);
    }
}
