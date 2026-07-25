using UnityEngine;

[CreateAssetMenu(fileName = "TriShotSkill", menuName = "Skills/Passive/TriShot")]
public class TriShotSkillSO : PassiveSkillSO
{
    public override void Apply(GameObject player)
    {
        PlayerShooting shooting = player.GetComponent<PlayerShooting>();
        if (shooting != null)
        {
            shooting.tripleShotEnabled = true;
        }
        else
        {
            Debug.LogWarning("PlayerShooting gak ketemu di GameObject player!");
        }
    }
}
