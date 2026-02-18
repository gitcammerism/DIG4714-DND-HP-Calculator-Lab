using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    // variables
    private CharacterHp player;
    public int constitution;
    public string characterRace;
    public string characterClass;
    public string characterName;
    public int characterLevel;
    public string feat; // "tough" or "stout"
    public string hpStyle; // "average" or "roll"


    // Start is called before the first frame update
    void Start()
    {
        // instantiate DND player with HP calculations
        player = new CharacterHp(characterName, constitution, characterRace, feat, hpStyle, characterLevel, characterClass);
        player.DisplayInfo();
    }

}
