using UnityEngine;

[CreateAssetMenu(fileName = "LaserSkill", menuName = "Skills/Active/Laser")]
public class LaserSkillSO : ActiveSkillSO
{
    [Header("Pengaturan Laser")]
    public float laserLength = 15f;   // sepanjang apa laser ke depan
    public float laserDuration = 3f;  // berapa detik laser nyala sebelum mati sendiri

    public override void Activate(PlayerSkillController caster)
    {
        if (caster.laserBeam == null)
        {
            Debug.LogWarning("laserBeam belum di-assign di PlayerSkillController!");
            return;
        }

        caster.laserBeam.StartBeam(laserLength, laserDuration);
    }
}
