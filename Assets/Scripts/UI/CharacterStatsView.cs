using Pools;
using SimpleEventBus.Disposables;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _statsRoot;
    [SerializeField] 
    private CharacterStatView _statPrefab;


    private MonoBehaviourPool<CharacterStatView> _statsPool;
    private CompositeDisposable _subscriptions;
    
    private void Awake()
    {
        _statsPool = new MonoBehaviourPool<CharacterStatView>(_statPrefab, _statsRoot);
        _subscriptions = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<CharacterSelectedEvent>(OnCharacterSelected)
        };
    }

    private void OnCharacterSelected(CharacterSelectedEvent eventData)
    {
        _statsPool.ReleaseAll();
        var selectedCharacter = eventData.Character;
        foreach (var stat in selectedCharacter.characterStats)
        {
            _statsPool.Take().Initialize(stat);
        }
    }

    private void OnDestroy()
    {
        _subscriptions?.Dispose();
    }
}