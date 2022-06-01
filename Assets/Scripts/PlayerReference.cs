using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerReference : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField]
    private Color[] clr_Players;
    [SerializeField]
    private Sprite[] spr_Turrets;
    [SerializeField]
    private float PlayerMoveSpeed, PlayerRotateSpeed;
    [Header("Prefabs")]
    [SerializeField]
    private GameObject pf_player;
    [SerializeField]
    private GameObject[] pf_maps;
    [Header("Scene Transforms")]
    [SerializeField]
    private Transform tf_MainCanvas;
    [Header("UI")]
    [SerializeField]
    private TMP_Text txt_InfoOne, txt_InfoTwo;

    public static Color[] s_clr_Players;
    public static Sprite[] s_spr_Turrets;
    public static float s_PlayerMoveSpeed;
    public static float s_PlayerRotateSpeed;
    public static GameObject s_pf_player;
    public static GameObject[] s_pf_maps;
    public static Transform s_tf_MainCanvas;
    public static TMP_Text s_txt_InfoOne, s_txt_InfoTwo;
    void Awake()
    {
        s_clr_Players = clr_Players;
        s_spr_Turrets = spr_Turrets;
        s_PlayerMoveSpeed = PlayerMoveSpeed;
        s_PlayerRotateSpeed = PlayerRotateSpeed;
        s_pf_player = pf_player;
        s_pf_maps = pf_maps;
        s_tf_MainCanvas = tf_MainCanvas;
        s_txt_InfoOne = txt_InfoOne;
        s_txt_InfoTwo = txt_InfoTwo;
    }
}
