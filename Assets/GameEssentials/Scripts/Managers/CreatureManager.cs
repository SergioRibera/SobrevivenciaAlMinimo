using System;
using UnityEngine;

public class CreatureManager : MonoBehaviour {
    
    public static CreatureManager Main = null;

    void Awake() {
        if (Main == null)
            Main = this;
        else
            Destroy(gameObject);
    }

    public void Init(){
        /* throw new NotImplementedException(); */
    }
}
