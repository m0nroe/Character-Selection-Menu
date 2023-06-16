using SimpleEventBus.Events;

public class CharacterSelectedEvent : EventBase
{
    public CharacterModel Character;

    public CharacterSelectedEvent(CharacterModel character)
    {
        Character = character;
    }
}