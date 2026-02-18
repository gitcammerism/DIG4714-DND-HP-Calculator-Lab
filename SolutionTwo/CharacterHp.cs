using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHp : Character
{
    protected int hp;

    public CharacterHp(string charName, int constitution, string race, string feat, string hpStyle, int level, string charClass)
    {
        hp = 0;
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
        for(int i = 0; i < level; i++)
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

    private int raceHp()
    {
        // add HP based on Dwarf, Orc, or Goliath
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

    private int featHp()
    {
        // add HP based on Tough or Stout feat
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

    // the public method to be called during instantiation; calculates the total hp
    public int calculateHp()
    {
        switch(hpStyle)
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
}
