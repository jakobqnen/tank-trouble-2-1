using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerReference : MonoBehaviour
{
    [SerializeField]
    private GameObject pf_player;
    [SerializeField]
    private GameObject[] pf_maps;
    [SerializeField]
    private Transform tf_MainCanvas;
    [SerializeField]
    private TMP_Text txt_InfoOne, txt_InfoTwo;
    public static GameObject s_pf_player;
    public static GameObject[] s_pf_maps;
    public static Transform s_tf_MainCanvas;
    public static TMP_Text s_txt_InfoOne, s_txt_InfoTwo;
    void Awake()
    {
        s_pf_player = pf_player;
        s_pf_maps = pf_maps;
        s_tf_MainCanvas = tf_MainCanvas;
        s_txt_InfoOne = txt_InfoOne;
        s_txt_InfoTwo = txt_InfoTwo;
    }
}
