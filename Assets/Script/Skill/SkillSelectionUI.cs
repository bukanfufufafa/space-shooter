using UnityEngine;

/// <summary>
/// Tempel di Canvas (atau GameObject manapun yang gampang diakses).
/// Method di bawah ini yang di-drag ke tombol OnClick lewat Inspector.
/// </summary>
public class SkillSelectionUI : MonoBehaviour
{
    [Header("Referensi")]
    public StageManager stageManager;
    public PlayerSkillController playerSkillController; // buat active skill
    public GameObject player;                            // buat passive skill (GetComponent di dalamnya)

    [Header("Panel")]
    public GameObject activeSkillPanel;
    public GameObject passiveSkillPanel;

    /// <summary>Drag ke OnClick tombol active skill (Laser / Time Slow).</summary>
    public void ChooseActiveSkill(ActiveSkillSO skill)
    {
        playerSkillController.SetSkill(skill);
        activeSkillPanel.SetActive(false);
        stageManager.AdvanceToNextStage();
    }

    /// <summary>Drag ke OnClick tombol passive skill (Tri Shot / Extra Life).</summary>
    public void ChoosePassiveSkill(PassiveSkillSO skill)
    {
        skill.Apply(player);
        passiveSkillPanel.SetActive(false);
        stageManager.AdvanceToNextStage();
    }
}
