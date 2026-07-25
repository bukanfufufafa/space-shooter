using UnityEngine;

public enum GameStage { Stage1, Stage2, Stage3, Done }

public class StageManager : MonoBehaviour
{
    [Header("Panel UI (drag dari Hierarchy)")]
    public GameObject activeSkillPanel;   // muncul setelah Stage 1 selesai
    public GameObject passiveSkillPanel;  // muncul setelah Stage 2 selesai

    public GameStage currentStage = GameStage.Stage1;

    /// <summary>
    /// Panggil method ini dari tempat kalian nentuin "stage selesai"
    /// (misal: musuh terakhir mati, atau wave/timer stage habis).
    /// </summary>
    public void OnStageCleared()
    {
        switch (currentStage)
        {
            case GameStage.Stage1:
                ShowPanel(activeSkillPanel);
                break;

            case GameStage.Stage2:
                ShowPanel(passiveSkillPanel);
                break;

            case GameStage.Stage3:
                Debug.Log("Semua stage selesai!");
                currentStage = GameStage.Done;
                // lanjut ke scene menang / ending, dll
                break;
        }
    }

    private void ShowPanel(GameObject panel)
    {
        Time.timeScale = 0f; // pause game selagi player milih (opsional, boleh dihapus)
        panel.SetActive(true);
    }

    /// <summary>Dipanggil dari SkillSelectionUI setelah player selesai memilih.</summary>
    public void AdvanceToNextStage()
    {
        Time.timeScale = 1f;

        switch (currentStage)
        {
            case GameStage.Stage1: currentStage = GameStage.Stage2; break;
            case GameStage.Stage2: currentStage = GameStage.Stage3; break;
        }

        Debug.Log($"Lanjut ke {currentStage}");
        // load/mulai stage berikutnya sesuai sistem kalian di sini
        // contoh: SceneManager.LoadScene(currentStage.ToString());
    }
}
