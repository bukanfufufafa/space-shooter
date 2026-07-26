using UnityEngine;

public enum GameStage { Stage1, Stage2, Stage3, Done }

public class StageManager : MonoBehaviour
{
    [Header("Panel UI (drag dari Hierarchy)")]
    public GameObject activeSkillPanel; 
    public GameObject passiveSkillPanel; 

    [Header("Wave Stage 2 & 3 (drag GameObject yang ada wavetrigger-nya)")]
    public GameObject stage2Waves; 
    public GameObject stage3Waves; 

    public GameStage currentStage = GameStage.Stage1;

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

    public void AdvanceToNextStage()
    {
        Time.timeScale = 1f;

        switch (currentStage)
        {
            case GameStage.Stage1:
                currentStage = GameStage.Stage2;
                if (stage2Waves != null) stage2Waves.SetActive(true);
                break;

            case GameStage.Stage2:
                currentStage = GameStage.Stage3;
                if (stage3Waves != null) stage3Waves.SetActive(true);
                break;
        }

        Debug.Log($"Lanjut ke {currentStage}");
    }

    public void ResetStage()
    {
        currentStage = GameStage.Stage1;
        Time.timeScale = 1f;
        activeSkillPanel.SetActive(false);
        passiveSkillPanel.SetActive(false);

        if (stage2Waves != null) stage2Waves.SetActive(false);
        if (stage3Waves != null) stage3Waves.SetActive(false);
    }
}