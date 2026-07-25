using UnityEngine;

/// <summary>
/// Base class untuk semua Active Skill.
/// Bikin skill baru = bikin class baru yang extend ini (contoh: LaserSkillSO).
/// Activate() dipanggil saat spasi DITEKAN.
/// Deactivate() dipanggil saat spasi DILEPAS (skill sekali tembak/instant boleh
/// biarkan kosong, tidak wajib di-override).
/// </summary>
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
