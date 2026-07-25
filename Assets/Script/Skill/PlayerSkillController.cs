using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    [Header("Skill yang dipilih player (diisi lewat SetSkill saat pemilihan)")]
    public ActiveSkillSO selectedSkill;

    [Header("Referensi Laser (child dari firePoint, taruh manual di Inspector)")]
    public LaserBeamController laserBeam;

    private int usesLeft;

    private void Start()
    {
        ResetUsesForNewStage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryActivateSkill();
        }
    }

    private void TryActivateSkill()
    {
        if (selectedSkill == null) return;

        if (usesLeft <= 0)
        {
            Debug.Log("Skill sudah habis dipakai untuk stage ini!");
            return;
        }

        selectedSkill.Activate(this);
        usesLeft--;
        Debug.Log($"{selectedSkill.skillName} dipakai. Sisa pemakaian: {usesLeft}");
    }

    /// <summary>Panggil dari StageManager tiap kali stage baru mulai.</summary>
    public void ResetUsesForNewStage()
    {
        if (selectedSkill != null)
            usesLeft = selectedSkill.maxUsesPerStage;
    }

    /// <summary>Panggil dari UI pemilihan skill (setelah stage 1 selesai).</summary>
    public void SetSkill(ActiveSkillSO skill)
    {
        selectedSkill = skill;
        ResetUsesForNewStage();
    }

    public int GetUsesLeft() => usesLeft;

    /// <summary>Panggil ini pas mulai run baru - hapus skill yang kepilih sebelumnya.</summary>
    public void ResetSkill()
    {
        selectedSkill = null;
        usesLeft = 0;
    }
}