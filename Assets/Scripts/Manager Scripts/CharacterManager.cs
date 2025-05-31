using System;

public class CharacterManager : Singleton<CharacterManager>
{
    public event Action<CharacterDataSO> CharacterDataInitialized;

    public CharacterDataSO CurrentCharacterData { get; private set; }

    public void CharacterInitialized(CharacterDataSO characterData)
    {
        CurrentCharacterData = characterData;

        CharacterDataInitialized?.Invoke(characterData);
    }
}
