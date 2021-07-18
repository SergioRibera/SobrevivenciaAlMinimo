using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [Header("Interface")]
    public GameObject textAnyKey;
    [Header("Player")]
    public Image healthImage;
    [Header("Menus")]
    public Animator animPlayerUI;

    public static UIManager Main = null;
    void Awake(){
        if (Main == null)
            Main = this;
    }

    public void UpdateHealth (int healt) {
        healthImage.fillAmount = healt;
    }

    public void ToglePauseMenu (bool enable) {
        throw new NotImplementedException();
    }

    public void InitGame() {
        ToggleTextAnyKey();
        // TODO: Enable Player Interface
        /* animPlayerUI.SetTrigger("Entry"); */
    }
    public void ToggleTextAnyKey() => textAnyKey.SetActive(!textAnyKey.activeSelf);
}
