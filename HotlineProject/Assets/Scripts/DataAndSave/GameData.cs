using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int energy;
    public int levelsCompleted;
    public int tokenScore;
    public bool[] tokens;
    public bool[] unlockedSkins;
}
