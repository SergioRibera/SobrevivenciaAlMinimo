using System.Collections.Generic;

public class CreatureData {
    public int health;
    public TypeAlimentation typeAlimentation;
    public List<Hability> habilities;
    public int level;
    public List<CreaturePart> parts;
    public int inputSelect,
           maxADN, currentNutrition, maxNutrition;

    public CreatureData() {
        health = 100;
        currentNutrition = 0;
        maxNutrition = 100;
        maxADN = 5;
        habilities = new List<Hability>();
        parts = new List<CreaturePart>();
        inputSelect = 0;
    }
}
