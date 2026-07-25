using UnityEngine;

public enum GameStage { Stage1, Stage2, Stage3, Done }

public class StageManager : MonoBehaviour
{
    [Header("Panel UI (drag dari Hierarchy)")]
    public GameObject activeSkillPanel;  
    public GameObject passiveSkillPanel;  

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
                break;
        }
    }

    private void ShowPanel(GameObject panel)
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }
    public void AdvanceToNextStage()
    {
        Time.timeScale = 1f;

        switch (currentStage)
        {
            case GameStage.Stage1: currentStage = GameStage.Stage2; break;
            case GameStage.Stage2: currentStage = GameStage.Stage3; break;
        }

        Debug.Log($"Lanjut ke {currentStage}");
    }
    
    public void ResetStage()
    {
        currentStage = GameStage.Stage1;
        Time.timeScale = 1f;
        activeSkillPanel.SetActive(false);
        passiveSkillPanel.SetActive(false);
    }
}