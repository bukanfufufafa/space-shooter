using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;

    /// <summary>
    /// Mengubah semua tampilan dialog.
    /// </summary>
    public void UpdateDialogue(string characterName, string dialogue, Sprite sprite)
    {
        // Nama karakter
        nameText.text = characterName;

        // Isi dialog
        dialogueText.text = dialogue;

        // Sprite karakter
        if (sprite != null)
        {
            characterImage.gameObject.SetActive(true);
            characterImage.sprite = sprite;
        }
        else
        {
            // Jika tidak ada sprite (contoh Narrator)
            characterImage.gameObject.SetActive(false);
        }
    }
}