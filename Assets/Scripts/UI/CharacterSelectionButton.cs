using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionButton : MonoBehaviour
{
    [SerializeField]
    private Image _characterIcon;

    [SerializeField] 
    private TextMeshProUGUI _characterName;

    private CharacterModel _character;

    public void Initialize(CharacterModel character)
    {
        _character = character;
        _characterIcon.sprite = character.Icon;
        _characterName.text = character.Name;
    }

    [UsedImplicitly]
    public void OnClick()
    {
        Select();
    }

    public void Select()
    {
        EventStreams.Game.Publish(new CharacterSelectedEvent(_character));
    }

}
