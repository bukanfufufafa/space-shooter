using UnityEngine;

public abstract class ActiveSkillSO : ScriptableObject
{
    [Header("Info Umum")]
    public string skillName;
    [TextArea] public string description;
    public Sprite icon;

    [Header("Pengaturan Penggunaan")]
    public int maxUsesPerStage = 3;

    public abstract void Activate(PlayerSkillController caster);

    public virtual void Deactivate(PlayerSkillController caster) { }
}