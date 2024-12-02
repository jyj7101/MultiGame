using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class ChatManager : MonoBehaviourPunCallbacks
{
    public Button sendBtn; //ä�� �Է¹�ư
    public TextMeshProUGUI chatLog; //ä�� ����
    public TMP_InputField inputField; //ä���Է� ��ǲ�ʵ�
    public TextMeshProUGUI playerList; //������ ���
    string players; //�����ڵ�
    ScrollRect scroll_rect = null; //ä���� ���� ���� ��� ��ũ�ѹ��� ��ġ�� �Ʒ��� �����ϱ� ����

    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        scroll_rect = GameObject.FindObjectOfType<ScrollRect>();
    }

    void Update()
    {
        //ChatterUpdate();
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
        inputField.ActivateInputField(); // �޼��� ���� �� �ٷ� �޼����� �Է��� �� �ְ� ��Ŀ���� Input Field�� �ű�� ���� ���
        inputField.text = "";
    }

    //void ChatterUpdate()
    //{
    //    players = "������ ���\n";
    //    foreach (Player p in PhotonNetwork.PlayerList)
    //    {
    //        players += p.NickName + "\n";
    //    }
    //    playerList.text = players;
    //}


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        string msg = string.Format("<color=#00ff00>[{0}]���� �����ϼ̽��ϴ�.</color>", newPlayer.NickName);
        ReceiveMsg(msg);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        string msg = string.Format("<color=#ff0000>[{0}]���� �����ϼ̽��ϴ�.</color>", otherPlayer.NickName);
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

    //public void GameStart()
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        photonView.RPC("OnGameRoom", RpcTarget.AllBuffered);
    //    }
    //    else
    //    {
    //        Debug.Log("������ Ŭ���̾�Ʈ�� �ƴ�");
    //    }
    //}
    
    //[PunRPC]
    //public void OnGameRoom()
    //{
    //    PhotonNetwork.LoadLevel(2);
    //}

}