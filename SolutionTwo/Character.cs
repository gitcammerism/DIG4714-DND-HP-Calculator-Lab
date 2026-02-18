using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // variables
    protected string charName;
    protected int constitution;
    protected string race;
    protected string feat;
    protected string hpStyle;
    protected int level;
    protected string charClass;
    protected int hitDie;
    protected int constModifier;

    // dictionary with character race and hit die, <string, string>
    protected Dictionary<string, int> raceHitDie = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
    {
        {"Artificer", 8 },
        {"Barbarian", 12 },
        {"Bard", 8 },
        {"Cleric", 8 },
        {"Druid", 8 },
        {"Fighter", 10 },
        {"Monk", 8 },
        {"Ranger", 10 },
        {"Rogue", 8 },
        {"Paladin", 10 },
        {"Sorcerer", 6 },
        {"Wizard", 6 },
        {"Warlock", 8 },
    };

    // using array for con modifiers, where index is the constitution score
    protected int[] constMods = { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

    // if someone tries to call character with no parameters
    public Character()
    {
        charName = "No name";
        constitution = 0;
        race = "None";
        feat = "none";
        hpStyle = "none";
        level = 0;
        charClass = "none";
    }

    // constructor with all information
    public Character(string charName, int constitution, string race, string feat, string hpStyle, int level, string charClass)
    {
        this.charName = charName;
        this.constitution = constitution;
        this.race = race;
        this.feat = feat;
        this.hpStyle = hpStyle;
        this.level = level;
        this.charClass = charClass;
    }



}
