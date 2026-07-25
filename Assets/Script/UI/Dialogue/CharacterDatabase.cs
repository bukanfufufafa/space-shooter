using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string id;
    public Sprite sprite;
}

public class CharacterDatabase : MonoBehaviour
{
    [SerializeField] private CharacterData[] characters;

    public Sprite GetSprite(string id)
    {
        foreach (CharacterData character in characters)
        {
            if (character.id == id)
                return character.sprite;
        }

        return null;
    }
}