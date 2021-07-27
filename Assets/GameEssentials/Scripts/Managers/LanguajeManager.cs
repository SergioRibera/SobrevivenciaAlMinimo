using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguajeManager : MonoBehaviour {
    
    [SerializeField] string languajeSelected = "en";
    [SerializeField] ScriptableLanguaje dbLanguaje;
    [SerializeField] TMP_Dropdown languajeSelect;
    [SerializeField] List<TextForChange> texts;

    public static LanguajeManager Main = null;
    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    void Start(){
        languajeSelect.onValueChanged.AddListener((index) => {
            languajeSelected = dbLanguaje.GetLanguaje(index).Name;
            UpdateTextsLanguajes();
        });
        var langs = dbLanguaje.GetLanguajes();
        languajeSelect.AddOptions(langs);
        for(int i = 0; i < langs.Count; i++)
            if(langs[i] == languajeSelected)
                languajeSelect.value = i;
        foreach(var t in texts)
            t.textUI.text = dbLanguaje.TraduceByContent(t.textUI.text, languajeSelected);
        UpdateTextsLanguajes();
    }
    public void UpdateTextsLanguajes(){
        foreach(var t in texts)
            t.textUI.text = dbLanguaje.GetLanguajeContent(languajeSelected, t.indexContent).content;
    }

    public string TranslateContent (string content) => dbLanguaje.TraduceByContent(content, languajeSelected);
}
