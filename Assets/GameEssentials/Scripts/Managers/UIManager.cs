using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    [Header("Interface")]
    public GameObject textAnyKey;
    [Header("Player")]
    public Image healthImage;
    public Image typeAlImage;
    public Image nutritionPoint, adnPoint;
    public AdvancedUIInteractable interactable;
    public TextMeshProUGUI txtADN;
    [Header("Menus")]
    public Animator animPlayerHealth;
    public GameObject pauseMenu;
    public Transform pauseContainer;
    [Header("Notifications")]
    public Animator animNot;
    public TextMeshProUGUI notTitle, notMsg;
    [Header("Prefabs")]
    [SerializeField] GameObject btnPrefab;
    [SerializeField] List<GameObject> iconTypeAlimentation;

    public static UIManager Main = null;
    void Awake(){
        if (Main == null)
            Main = this;
    }

    public void UpdateNutritionPoint (float point) => nutritionPoint.fillAmount = point;
    public void UpdateHealth (float healt) => healthImage.fillAmount = healt;
    int valueAnimID = -1;
    public void UpdateADNPoint () {
        float value = 1.0f / (float) DataManager.MaxADN * (float) DataManager.ADN;
        txtADN.text = $"{DataManager.ADN} / {DataManager.MaxADN}";
        if (valueAnimID != -1)
            LeanTween.cancel(valueAnimID);
        valueAnimID = LeanTween.value(adnPoint.fillAmount, value, 1f).setOnUpdate((float v) => adnPoint.fillAmount = v).id;
    }

    public void UpdateLevel() {
        UpdateNutritionPoint(0f);
        // TODO: Add UI effect
    }

    public void EnableInteractable () => interactable.Interactive = true;

    GameObject goBtn;
    TMPro.TextMeshProUGUI txtBtn;
    public void UpdateUIParts () {
        pauseContainer.CleanChilds();
        foreach (var p in CreatureManager.Main.parts) {
            goBtn = Instantiate(btnPrefab, pauseContainer);
            AdvancedUIInteractable btnInt = goBtn.GetComponent<AdvancedUIInteractable>();
            txtBtn = goBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            txtBtn.text = string.IsNullOrEmpty(p.CreaturePart.name) ? "Uknown" : $"({p.CreaturePart.adnValue}) {p.CreaturePart.name}";
            btnInt.Interactive = p.CreaturePart.typeAlimentation == TypeAlimentation.Any || 
                    p.CreaturePart.typeAlimentation == DataManager.TypeAlimentation ||
                    DataManager.TypeAlimentation == TypeAlimentation.Any;
            if (CreaturePlayable.Main.ContainsPart(p))
                btnInt.colors.NormalColor = Color.cyan;
            btnInt.AddOnClickListener(() => {
                bool contains = CreaturePlayable.Main.ContainsPart(p);
                if (!contains)
                    // TODO: logic if Contains
                    contains = !CreaturePlayable.Main.AddCreaturePart(p);
                else
                    CreaturePlayable.Main.RemovePart(p);
                foreach (var icon in iconTypeAlimentation)
                    icon.SetActive(false);
                if (!contains)
                    if (p.CreaturePart.typeAlimentation != TypeAlimentation.Any) {
                        DataManager.TypeAlimentation = p.CreaturePart.typeAlimentation;
                        iconTypeAlimentation[(int) DataManager.TypeAlimentation].SetActive(true);
                    }
                btnInt.colors.NormalColor = !contains ? Color.cyan : Color.white;
            });
        }
    }
    public void ToglePauseMenu (bool e, bool update = false) {
        pauseMenu.SetActive(e);
        /* VerticalLayoutGroup vl = pauseMenu.GetComponent<VerticalLayoutGroup>(); */
        /* vl.enabled = false; */
        /* Vector2 pos = Vector2.right * 300 * (e ? 1 : -1); */
        /* var seq = LeanTween.sequence(); */
        /* for (int i = 0; i < pauseMenu.childCount; i++) { */
        /*     RectTransform child = pauseMenu.GetChild(i).GetComponent<RectTransform>(); */
        /*     seq.insert(LeanTween.move(child, pos, .5f).setDelay(.5f * i)); */
        /* } */
        /* vl.enabled = true; */
    }

    public void InitGame() {
        ToggleTextAnyKey();
        // TODO: Enable Player Interface
        animPlayerHealth.SetTrigger("Entry");
    }
    public void ToggleTextAnyKey() => textAnyKey.SetActive(!textAnyKey.activeSelf);
    public void ShowNotification(string msg, float wait, string title = "") => StartCoroutine(ShowNotification(msg, title, wait));

    IEnumerator ShowNotification(string msg, string title, float wait) {
        animNot.SetTrigger("Entry");
        if (!string.IsNullOrEmpty(title))
            notTitle.text = title;
        notMsg.text = msg;
        yield return new WaitForSeconds(wait);
        animNot.SetTrigger("Exit");
    }    
}
