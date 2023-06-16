using UnityEngine;

public class CharacterSelectionView : MonoBehaviour
{
    [SerializeField] 
    private CharactersProvider _charactersProvider;

    [SerializeField] 
    private CharactersCatalog _charactersCatalog;

    private void Start()
    {
        _charactersCatalog.Initialize(_charactersProvider);
    }
}