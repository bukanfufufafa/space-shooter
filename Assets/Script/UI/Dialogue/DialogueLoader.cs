using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    [SerializeField] private string fileName = "Dialog/intro";

    private DialogueList dialogueList;

    private void Start()
    {
        LoadDialogue();
    }

    private void LoadDialogue()
    {
        // Membaca file dari Resources
        TextAsset json = Resources.Load<TextAsset>(fileName);

        if (json == null)
        {
            Debug.LogError("File JSON tidak ditemukan!");
            return;
        }

        // Mengubah JSON menjadi object C#
        dialogueList = JsonUtility.FromJson<DialogueList>(json.text);

        Debug.Log("Jumlah Dialog : " + dialogueList.dialogues.Length);

        // Menampilkan isi dialog ke Console
        foreach (Dialogue dialogue in dialogueList.dialogues)
        {
            Debug.Log(dialogue.name + " : " + dialogue.text);
        }
    }
}