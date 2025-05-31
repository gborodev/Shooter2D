using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot : MonoBehaviour, ISelectHandler
{
    public event Action<CharacterSlot> OnSelected;

    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI characterStatInfoText;

    public CharacterDataSO CharacterData { get; private set; }

    public void Initialize(CharacterDataSO characterData)
    {
        characterData.InitializeCharacterData();

        CharacterData = characterData;
        characterNameText.text = characterData.characterName;
        characterStatInfoText.text = characterData.CharacterStatInfo;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (CharacterData == null) return;

        OnSelected?.Invoke(this);
    }
}
