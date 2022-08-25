using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class RoomManger : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TMP_InputField inp_createInput;
    [SerializeField]
    private TMP_Text txt_errorText;
    [SerializeField]
    private GameObject go_joinRoomButtonPrefab, go_roomList;
    private List<string> currentRoomNames = new List<string>();

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(inp_createInput.text))
        {
            SendError("Failed to create room: Please enter a room name");
            return;
        }
        PhotonNetwork.CreateRoom(inp_createInput.text);
    }
    public override void OnCreatedRoom()
    {
        print("created room9");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        SendError(message);
    }
    public void ShowRoomList()
    {
        go_roomList.SetActive(true);
        // Clear current buttons
        for (int i = go_joinRoomButtonPrefab.transform.parent.childCount - 1; i > -1; i--)
        {
            if (i == go_joinRoomButtonPrefab.transform.GetSiblingIndex()) continue;
            var child = go_joinRoomButtonPrefab.transform.parent.GetChild(i).gameObject;
            Destroy(child);
        }
        // Populate list
        foreach (string roomName in currentRoomNames)
        {
            var newJoinRoomButton = Instantiate(go_joinRoomButtonPrefab, parent: go_joinRoomButtonPrefab.transform.parent);
            newJoinRoomButton.SetActive(true);
            var newJoinRoomButtonText = newJoinRoomButton.transform.Find("Text").GetComponent<TMP_Text>();
            newJoinRoomButtonText.text = roomName;
            // Add to the button's onclick a new lambda function that has one line to join the room with the given name
            newJoinRoomButton.GetComponent<Button>().onClick.AddListener(() => PhotonNetwork.JoinRoom(roomName));
        }
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        SendError(message);
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
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print("room list update");
        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList)
            {
                currentRoomNames.Remove(room.Name);
                continue;
            }
            if (currentRoomNames.Contains(room.Name)) continue;
            currentRoomNames.Add(room.Name);
        }
    }

}
