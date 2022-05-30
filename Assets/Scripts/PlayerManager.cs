using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public Transform tf_MainCanvas;
    public TMP_Text txt_InfoOne, txt_InfoTwo;
    public static Transform s_tf_MainCanvas;
    public static TMP_Text s_txt_InfoOne, s_txt_InfoTwo;
    void Start()
    {
        s_tf_MainCanvas = tf_MainCanvas;
        s_txt_InfoOne = txt_InfoOne;
        s_txt_InfoTwo = txt_InfoTwo;
    }
}
