using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHp : Character
{
    protected int hp;
    // private readonly Character _character;

    // constructor
    public CharacterHp(string charName, int constitution, string race, string feat, string hpStyle, int level, string charClass)
    {
        hp = 0;
        this.charName = charName;
        this.constitution = constitution;
        this.race = race;
        this.feat = feat;
        this.hpStyle = hpStyle;
        this.level = level;
        this.charClass = charClass;

    }

    // calculate averaged hp
    private int averagedHp()
    {
        // hp = (level * avg(raceHitDie[charClass])) + (level * constMods[constitution - 1]);
        hp = level * (avg(raceHitDie[charClass]) + constMods[constitution - 1]);

        return hp;
    }

    // calculate rolled hp
    private int rolledHp()
    {
        for (int i = 0; i < level; i++)
        {
            hp += UnityEngine.Random.Range(1, raceHitDie[charClass] + 1) + constMods[constitution - 1];
        }

        return hp;
    }

    // averaged hitDie
    private int avg(double hitDie)
    {
        return (int)Math.Ceiling((hitDie + 1) / 2);
    }

    // add HP based on Dwarf, Orc, or Goliath
    private int raceHp()
    {
        int additionalHp = 0;
        switch (race)
        {
            case "Dwarf":
                additionalHp += 2 * level;
                break;
            case "Orc":
            case "Goliath":
                additionalHp += 1 * level;
                break;
            default:
                break;
        }
        return additionalHp;
    }

    // add HP based on Tough or Stout feat
    private int featHp()
    {
        int additionalHp = 0;
        switch (feat)
        {
            case "Tough":
                additionalHp += 2 * level;
                break;
            case "Stout":
                additionalHp += 1 * level;
                break;
            default:
                feat = "no";
                break;
        }
        return additionalHp;
    }

    // the method to be called to calculate the total HP
    public int calculateHp()
    {
        switch (hpStyle)
        {
            case "averaged":
                hp = averagedHp() + raceHp() + featHp();
                break;
            case "rolled":
                hp = rolledHp() + raceHp() + featHp();
                break;
            default:
                Debug.Log("Invalid HP style.");
                break;
        }

        return hp;
    }

    // overrides Character's DisplayInfo() and calls calculateHp() and prints it
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Debug.Log($"HP: {calculateHp()}");
    }

}