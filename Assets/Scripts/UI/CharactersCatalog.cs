using System;
using System.Linq;
using Pools;
using UnityEngine;

public class CharactersCatalog : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _buttonsRoot;

    [SerializeField] 
    private CharacterSelectionButton _buttonPrefab;

    private MonoBehaviourPool<CharacterSelectionButton> _selectionButtonsPool;
    
    private void Awake()
    {
        _selectionButtonsPool = new MonoBehaviourPool<CharacterSelectionButton>(_buttonPrefab, _buttonsRoot);
    }
    
    public void Initialize(CharactersProvider charactersProvider)
    {
        var characters = charactersProvider.GetAllCharacters();
        
        
        foreach (var character in characters)
        {
            var characterSelectionButton = _selectionButtonsPool.Take();
            //Debug.Log("is pool characterSelectionButton null" + characterSelectionButton == null);

            characterSelectionButton.Initialize(character);
        }
        var defaultSelected = _selectionButtonsPool.UsedItems.Last();
        defaultSelected.Select();
    }
}
