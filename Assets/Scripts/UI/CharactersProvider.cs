using System.Collections.Generic;
using UnityEngine;

public class CharactersProvider : MonoBehaviour
{
    [SerializeField] private CharacterModel[] _characters;
    private readonly Dictionary<string, CharacterModel> _charactersByName = new ();

    private void Awake()
    {
        foreach (var character in _characters)
        {
            _charactersByName[character.Name] = character;
        }
    }

    public CharacterModel[] GetAllCharacters()
    {
        return _characters;
    }

    public CharacterModel GetCharacter(string characterName)
    {
        return _charactersByName[characterName];
    }
}