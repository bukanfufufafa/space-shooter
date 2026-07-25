using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;

    [Header("Typewriter Settings")]
    [SerializeField] private float kecepatanKetik = 0.03f; // delay antar huruf (detik)

    private Coroutine typingCoroutine;
    private string dialogPenuh; // menyimpan teks lengkap dialog saat ini

    public bool SedangMengetik { get; private set; }

    public void UpdateDialogue(string characterName, string dialogue, Sprite sprite)
    {
        nameText.text = characterName;

        if (sprite != null)
        {
            characterImage.gameObject.SetActive(true);
            characterImage.sprite = sprite;
        }
        else
        {
            characterImage.gameObject.SetActive(false);
        }

        // Hentikan efek ketik dialog sebelumnya kalau masih berjalan
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogPenuh = dialogue;
        typingCoroutine = StartCoroutine(EfekKetik());
    }

    private IEnumerator EfekKetik()
    {
        SedangMengetik = true;
        dialogueText.text = "";

        foreach (char huruf in dialogPenuh)
        {
            dialogueText.text += huruf;
            yield return new WaitForSeconds(kecepatanKetik);
        }

        SedangMengetik = false;
    }

    // Dipanggil kalau player klik pas teks masih lagi ngetik
    public void TampilkanTeksLangsung()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = dialogPenuh;
        SedangMengetik = false;
    }
}