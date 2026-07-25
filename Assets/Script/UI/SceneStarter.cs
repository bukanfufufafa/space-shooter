using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStarter : MonoBehaviour
{
    void Start()
    {
        DialogueManager.Instance.Mainkan("Dialog/dialog_prolog", "_UITest");
    }
}
