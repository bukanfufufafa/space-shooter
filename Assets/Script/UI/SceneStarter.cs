using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStarter : MonoBehaviour
{   
    public string namaDialog;
    void Start()
    {
        DialogueManager.Instance.Mainkan(namaDialog, "_UITest");
    }
}
