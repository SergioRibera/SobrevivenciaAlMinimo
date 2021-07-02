using UnityEngine;
usign UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Image healthImage;

    public static UIManager Main = null;
    void Awake(){
        if (Main == null)
            Main = this;
    }

    public void UpdateHealth(int healt) {
        healthImage.fill = healt;
    }
}
