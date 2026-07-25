using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeStopSkill", menuName = "Skills/Active/TimeStop")]
public class TimeStopSkillSO : ActiveSkillSO
{
    [Header("Pengaturan Time Slow")]
    [Range(0.05f, 1f)] public float slowScale = 0.3f; // seberapa lambat dunia (0.3 = 30% speed normal)
    public float duration = 3f;                        // berapa detik efeknya jalan

    public override void Activate(PlayerSkillController caster)
    {
        // caster adalah MonoBehaviour, jadi ScriptableObject numpang StartCoroutine di dia
        caster.StartCoroutine(TimeStopRoutine());
    }

    private IEnumerator TimeStopRoutine()
    {
        float defaultFixedDelta = 0.02f; // default Unity, sesuaikan kalau project kalian beda

        Time.timeScale = slowScale;
        Time.fixedDeltaTime = defaultFixedDelta * slowScale;

        // WaitForSecondsRealtime dipakai karena timeScale sudah diubah,
        // kalau pakai WaitForSeconds biasa durasinya ikut molor
        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = defaultFixedDelta;
    }
}
