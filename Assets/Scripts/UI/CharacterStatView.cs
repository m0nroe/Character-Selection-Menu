using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatView : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _statValue;
    [SerializeField]
    private TextMeshProUGUI _statLabel;
    [SerializeField] 
    private TextMeshProUGUI _statNumericValue;

    public void Initialize(CharacterStat characterStat)
    {
        _statValue.size = characterStat.Value / (float) characterStat.MaxValue;
        _statLabel.text = characterStat.Type.ToString();
        _statNumericValue.text = $"{characterStat.Value}/{characterStat.MaxValue}";
    }
}