using UnityEngine;

/// <summary>
/// Base class untuk semua Passive Skill.
/// Beda dengan Active Skill: passive cuma diterapkan SEKALI pas dipilih,
/// gak ada input/tombol buat makainya.
/// </summary>
public abstract class PassiveSkillSO : ScriptableObject
{
    [Header("Info Umum")]
    public string skillName;
    [TextArea] public string description;
    public Sprite icon;

    /// <summary>Dipanggil sekali, langsung pas player memilih skill ini.</summary>
    public abstract void Apply(GameObject player);
}
