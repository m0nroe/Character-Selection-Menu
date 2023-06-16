using System;
using UnityEngine;

[Serializable]
public class CharacterModel
{
    public string Name;
    public GameObject Prefab;
    public Sprite Icon;
    public CharacterStat[] characterStats;
}