using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Transform slotContent;
    [SerializeField] private CharacterSlot slotPrefab;

    private List<CharacterSlot> characterSlots;

    public void OnEnable()
    {
        GameManager.instance.DatabaseInitialized += InitializeSlots;
    }
    public void OnDisable()
    {
        GameManager.instance.DatabaseInitialized -= InitializeSlots;
    }

    private void InitializeSlots(Database database)
    {
        characterSlots = new List<CharacterSlot>();

        foreach (var data in database.characters)
        {
            CharacterSlot slot = Instantiate(slotPrefab, slotContent);
            slot.Initialize(data);

            slot.OnSelected += OnCharacterSelected;

            characterSlots.Add(slot);
        }

        EventSystem.current.SetSelectedGameObject(characterSlots[0].gameObject);
    }

    private void OnCharacterSelected(CharacterSlot slot)
    {
        Debug.Log($"Character selected: {slot.CharacterData.characterName}");
    }
}
