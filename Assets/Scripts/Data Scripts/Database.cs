using UnityEngine;

[CreateAssetMenu(menuName = "Database/Game Database", fileName = "New Database")]
public class Database : ScriptableObject
{
    public CharacterDataSO[] characters; // Array of character data objects
}
