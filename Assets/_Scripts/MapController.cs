using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MapController : MonoBehaviour
{
    PhotonView pho_Map;
    void Start()
    {
        transform.parent = PlayerReference.s_tf_MainCanvas;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
