using System.Collections.Generic;

public class CreatureData {
    public int health;
    public TypeAlimentation typeAlimentation;
    public List<Hability> habilities;
    public int level;
    public List<CreaturePart> parts;
    public List<string> partsNames;
    public int inputSelect,
           adn, maxADN, currentNutrition, maxNutrition;

    public CreatureData() {
        health = 100;
        currentNutrition = 0;
        maxNutrition = 100;
        adn = 0;
        // maxADN = 5;
        maxADN = 4;
        level = -1;
        habilities = new List<Hability>();
        parts = new List<CreaturePart>();
        partsNames = new List<string>();
        inputSelect = 0;
        typeAlimentation = TypeAlimentation.Any;
    }
}
