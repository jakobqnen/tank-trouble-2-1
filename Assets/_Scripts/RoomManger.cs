using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class RoomManger : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TMP_InputField inp_createInput;
    [SerializeField]
    private TMP_Text txt_errorText;
    [SerializeField]
    private GameObject go_joinRoomButtonPrefab, go_roomList;
    private List<string> currentRoomNames = new List<string>() { "peepee", "poopoo", "epeopowe" };

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(inp_createInput.text))
        {
            SendError("Failed to create room: Please enter a room name");
            return;
        }
        PhotonNetwork.CreateRoom(inp_createInput.text);
        currentRoomNames.Add(inp_createInput.text);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        SendError(message);
    }
    public void ShowRoomList()
    {
        go_roomList.SetActive(true);
        foreach (string roomName in currentRoomNames)
        {
            var newJoinRoomButton = Instantiate(go_joinRoomButtonPrefab, parent: go_joinRoomButtonPrefab.transform.parent);
            newJoinRoomButton.SetActive(true);
            var newJoinRoomButtonText = newJoinRoomButton.transform.Find("Text").GetComponent<TMP_Text>();
            newJoinRoomButtonText.text = roomName;
        }
    }

    private void SendError(string errorMessage)
    {
        txt_errorText.text = errorMessage;
        txt_errorText.gameObject.SetActive(true);
        Invoke("CloseError", 3f);
    }
    private void CloseError()
    {
        txt_errorText.gameObject.SetActive(false);
    }

}
