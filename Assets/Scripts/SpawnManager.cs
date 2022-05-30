using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject pf_player;


    void Start()
    {
        PhotonNetwork.Instantiate(pf_player.name, GetRandomValidPosition(), Quaternion.identity);
    }

    Vector2 GetRandomValidPosition()
    {
        return new Vector2(Random.Range(0, 1080), Random.Range(0, 1080));
    }
}
