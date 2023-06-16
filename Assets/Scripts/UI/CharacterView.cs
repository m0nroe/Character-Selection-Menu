using System;
using SimpleEventBus.Disposables;
using UnityEditor;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] 
    private Transform objectRoot;
    
    private CompositeDisposable _subscriptions;
    private GameObject _characterObject;
    
    private void Awake()
    {
        _subscriptions = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<CharacterSelectedEvent>(OnCharacterSelected),
            EventStreams.Game.Subscribe<RotationEvent>(OnObjectRotated),
        };
    }

    private void OnCharacterSelected(CharacterSelectedEvent eventData)
    {
        if (_characterObject != null)
        {
            Destroy(_characterObject);
        }

        _characterObject = Instantiate(eventData.Character.Prefab, objectRoot);
        _characterObject.SetActive(true);
        _characterObject.transform.rotation = Quaternion.identity;
    }

    private void OnObjectRotated(RotationEvent eventData)
    {
        if (_characterObject != null)
        {
            _characterObject.transform.Rotate(0, -eventData.Delta, 0);
        }
    }

    private void OnDestroy()
    {
        _subscriptions?.Dispose();
    }
}