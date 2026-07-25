using UnityEngine;


public class DebugTools : MonoBehaviour
{
    [Header("Referensi")]
    public StageManager stageManager;
    public PlayerHealth playerHealth;
    public PlayerPowerController playerPowerController;
    public GameObject player; // buat DebugListComponents()

    /// <summary>Simulasi "stage selesai" tanpa perlu wave/musuh beneran.</summary>
    public void ForceStageClear()
    {
        stageManager.OnStageCleared();
        Debug.Log("[DEBUG] Stage dipaksa selesai.");
    }

    /// <summary>Simulasi player kena damage 1x, buat cek power bar & HP.</summary>
    public void SimulateDamage()
    {
        playerHealth.TakeDamage(1);
        Debug.Log("[DEBUG] Player disimulasikan kena damage.");
    }

    /// <summary>Simulasi nambah power langsung, buat cek Full Power Mode.</summary>
    public void SimulateAddPower()
    {
        playerPowerController.AddPowerFromDamage(20f);
        Debug.Log("[DEBUG] Power ditambah manual +20.");
    }

    /// <summary>Reset run dari awal, buat cek semua reset jalan bener.</summary>
    public void ForceNewRun()
    {
        GameManager.Instance.StartNewRun();
        Debug.Log("[DEBUG] Run dipaksa restart.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ForceStageClear();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SimulateDamage();
        if (Input.GetKeyDown(KeyCode.Alpha3)) SimulateAddPower();
        if (Input.GetKeyDown(KeyCode.Alpha4)) ForceNewRun();
        if (Input.GetKeyDown(KeyCode.Alpha5)) DebugListComponents();
        if (Input.GetKeyDown(KeyCode.Alpha6)) playerPowerController.ForceFullPower();
    }

    /// <summary>Cetak semua GameObject + komponen di dalam Player ke Console,
    /// plus cek poin-poin spesifik yang sering bikin laser gak muncul.</summary>
    public void DebugListComponents()
    {
        if (player == null)
        {
            Debug.LogError("[DEBUG] Field 'player' di DebugTools belum di-assign!");
            return;
        }

        Debug.Log("========== DEBUG: Hierarchy & Component Player ==========");

        Transform[] allTransforms = player.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in allTransforms)
        {
            Component[] comps = t.GetComponents<Component>();
            string compList = "";
            foreach (Component c in comps)
            {
                if (c == null) { compList += "[MISSING SCRIPT] "; continue; }
                compList += c.GetType().Name + ", ";
            }
            Debug.Log($"[{(t.gameObject.activeInHierarchy ? "ACTIVE" : "INACTIVE")}] {t.name} -> {compList}");
        }

        Debug.Log("========== DEBUG: Cek Spesifik Laser ==========");

        // Cek FirePoint & LaserBeam ada
        Transform firePoint = player.transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("[DEBUG] 'FirePoint' TIDAK ketemu sebagai child Player!");
        }
        else
        {
            Transform laserBeam = firePoint.Find("LaserBeam");
            if (laserBeam == null)
            {
                Debug.LogError("[DEBUG] 'LaserBeam' TIDAK ketemu sebagai child FirePoint!");
            }
            else
            {
                SpriteRenderer sr = laserBeam.GetComponent<SpriteRenderer>();
                if (sr == null)
                    Debug.LogError("[DEBUG] LaserBeam TIDAK punya SpriteRenderer!");
                else if (sr.sprite == null)
                    Debug.LogError("[DEBUG] SpriteRenderer di LaserBeam ada, tapi field 'Sprite'-nya KOSONG!");
                else
                    Debug.Log($"[DEBUG] LaserBeam SpriteRenderer OK, sprite: {sr.sprite.name}, sorting order: {sr.sortingOrder}");

                LaserBeamController lbc = laserBeam.GetComponent<LaserBeamController>();
                Debug.Log(lbc == null
                    ? "[DEBUG] LaserBeam TIDAK punya script LaserBeamController!"
                    : "[DEBUG] LaserBeamController OK.");
            }
        }

        // Cek PlayerSkillController
        PlayerSkillController psc = player.GetComponent<PlayerSkillController>();
        if (psc == null)
        {
            Debug.LogError("[DEBUG] Player TIDAK punya PlayerSkillController!");
        }
        else
        {
            Debug.Log(psc.laserBeam == null
                ? "[DEBUG] Field 'Laser Beam' di PlayerSkillController BELUM di-assign!"
                : $"[DEBUG] PlayerSkillController.laserBeam OK -> {psc.laserBeam.name}");

            Debug.Log(psc.selectedSkill == null
                ? "[DEBUG] Field 'Selected Skill' di PlayerSkillController KOSONG (belum ada skill kepilih)!"
                : $"[DEBUG] PlayerSkillController.selectedSkill -> {psc.selectedSkill.skillName} (sisa pemakaian: {psc.GetUsesLeft()})");
        }

        Debug.Log("========== DEBUG SELESAI ==========");
    }
}