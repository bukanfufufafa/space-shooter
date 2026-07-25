using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    public DialogueList Muat(string namaFile)
    {
        TextAsset json = Resources.Load<TextAsset>(namaFile);

        if (json == null)
        {
            Debug.LogError($"File JSON '{namaFile}' tidak ditemukan di folder Resources!");
            return null;
        }

        return JsonUtility.FromJson<DialogueList>(json.text);
    }
}