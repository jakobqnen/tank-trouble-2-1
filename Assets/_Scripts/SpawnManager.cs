using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
public class SpawnManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(PlayerReference.s_pf_player.name, GetRandomValidPosition(), Quaternion.identity);

        GameObject[] maps = PlayerReference.s_pf_maps;
        Transform mapParent = PlayerReference.s_tf_MainCanvas.Find("Map").transform;
        if (!PhotonNetwork.IsMasterClient)
        {
            print("brosef");
            return;
        }
        GameObject map = PhotonNetwork.InstantiateRoomObject("Maps/" + maps[Random.Range(0, maps.Length)].name, Vector3.zero, Quaternion.identity);
        //map.transform.SetParent(mapParent);




    }

    Vector2 GetRandomValidPosition()
    {
        return new Vector2(Random.Range(0, 984.5f), Random.Range(0, 977.5f));
    }


}
