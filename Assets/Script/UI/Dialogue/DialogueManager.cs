using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [Header("Reference")]
    [SerializeField] private DialogueLoader loader;
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private CharacterDatabase database;
    [SerializeField] private GameObject panelDialog; // panel UI dialog (di-on/off-kan)

    private Dialogue[] dialogues;
    private int currentIndex = 0;
    private UnityAction aksiSetelahSelesai;
    private string sceneTujuanSaatIni;

    private void Awake()
    {
        // Singleton, biar cuma ada 1 dan bertahan lintas scene
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (panelDialog != null)
            panelDialog.SetActive(false);
    }

    private void Update()
    {
        if (panelDialog != null && !panelDialog.activeSelf) return;

        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    /// <summary>
    /// Panggil ini dari script mana pun untuk mulai dialog.
    /// namaScene: isi kalau setelah dialog ini harus pindah scene, kosongkan kalau tidak.
    /// onSelesai: aksi yang dijalankan setelah dialog selesai/di-skip (misal lanjutin gameplay).
    /// </summary>
    public void Mainkan(string namaFileJson, string namaScene = "", UnityAction onSelesai = null)
    {
        DialogueList data = loader.Muat(namaFileJson);
        if (data == null) return;

        dialogues = data.dialogues;
        currentIndex = 0;
        sceneTujuanSaatIni = namaScene;
        aksiSetelahSelesai = onSelesai;

        if (panelDialog != null)
            panelDialog.SetActive(true);

        TampilkanDialog();
    }

    private void HandleClick()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (dialogueUI.SedangMengetik)
            dialogueUI.TampilkanTeksLangsung();
        else
            NextDialogue();
    }

    private void TampilkanDialog()
    {
        Dialogue dialogSaatIni = dialogues[currentIndex];
        Sprite sprite = database.GetSprite(dialogSaatIni.sprite);
        dialogueUI.UpdateDialogue(dialogSaatIni.name, dialogSaatIni.text, sprite);
    }

    public void NextDialogue()
    {
        currentIndex++;

        if (currentIndex >= dialogues.Length)
        {
            SelesaikanDialog();
            return;
        }

        TampilkanDialog();
    }

    public void SkipDialogue() => SelesaikanDialog();

    private void SelesaikanDialog()
    {
        if (panelDialog != null)
            panelDialog.SetActive(false);

        if (!string.IsNullOrEmpty(sceneTujuanSaatIni))
        {
            SceneManager.LoadScene(sceneTujuanSaatIni);
            return;
        }

        aksiSetelahSelesai?.Invoke();
    }
}