using UnityEngine;

[CreateAssetMenu(fileName = "ExtraLifeSkill", menuName = "Skills/Passive/ExtraLife")]
public class ExtraLifeSkillSO : PassiveSkillSO
{
    public int extraLives = 1;

    public override void Apply(GameObject player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.AddExtraLives(extraLives);
        }
        else
        {
            Debug.LogWarning("PlayerHealth gak ketemu di GameObject player!");
        }
    }
}
