using SimpleEventBus.Events;

public class RotationEvent : EventBase
{
    public float Delta;

    public RotationEvent(float delta)
    {
        Delta = delta;
    }
}