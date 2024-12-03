using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class ChatManager : MonoBehaviourPunCallbacks
{
    public Button sendBtn; //채팅 입력버튼
    public TextMeshProUGUI chatLog; //채팅 내역
    public TMP_InputField inputField; //채팅입력 인풋필드
    string players; //참가자들
    ScrollRect scroll_rect = null; //채팅이 많이 쌓일 경우 스크롤바의 위치를 아래로 고정하기 위함

    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        scroll_rect = GetComponent<ScrollRect>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && !inputField.isFocused) SendButtonOnClicked();
    }

    public void SendButtonOnClicked()
    {
        if (inputField.text.Equals(""))
        {
            Debug.Log("Empty");
            return;
        }
        string msg = string.Format("[{0}] {1}", PhotonNetwork.LocalPlayer.NickName, inputField.text);
        photonView.RPC("ReceiveMsg", RpcTarget.OthersBuffered, msg);
        ReceiveMsg(msg);
        inputField.ActivateInputField(); 
        inputField.text = "";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        string msg = string.Format("<color=#00ff00>[{0}]님이 입장하셨습니다.</color>", newPlayer.NickName);
        ReceiveMsg(msg);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        string msg = string.Format("<color=#ff0000>[{0}]님이 퇴장하셨습니다.</color>", otherPlayer.NickName);
        ReceiveMsg(msg);
    }

    [PunRPC]
    public void ReceiveMsg(string msg)
    {
        chatLog.text += "\n" + msg;
        StartCoroutine(ScrollUpdate());
    }

    IEnumerator ScrollUpdate()
    {
        yield return null;
        scroll_rect.verticalNormalizedPosition = 0.0f;
    }
}