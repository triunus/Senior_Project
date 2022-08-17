using GetSetAccountInfo;
using ConnectServer;
using GetSetLobbyInfo;

using UnityEngine;

public class Login : MonoBehaviour
{
    LoginRegisterRequest loginRegisterRequest;
    GetSetAccountData getSetAccountData;
    GetSetLobbyData getSetLobbyData;

    private DisplayMessage displayMessage;

    string[] userData;
    string[] lobbyData;

    private void Awake()
    {
        getSetAccountData = new GetSetAccountData();
        loginRegisterRequest = new LoginRegisterRequest();
        getSetLobbyData = new GetSetLobbyData();

        displayMessage = GetComponent<DisplayMessage>();

        userData = new string[2];
    }

    public void LoginButtonOnClick()
    {
        Debug.Log("01. OnClicked Login Button");

        userData = getSetAccountData.GetAccountData();
        if (userData == null)
        {

            Debug.Log("02-1. 파일이 없어서 userData가 null값임.");
            displayMessage.Display(03);
            return;
        }
        Debug.Log("02. userData : " + userData + ", " + userData[0] + ", " + userData[1]);

        lobbyData = loginRegisterRequest.Login(userData);
        Debug.Log("03. lobbyData : " + lobbyData + ", " + lobbyData[0] + ", " + lobbyData[1] + ", " + lobbyData[2] + ", " + lobbyData[3] + ", " + lobbyData[4]);

        Debug.Log("LoginButtonOnClick04 : 로비 데이터 저장하러, 서버에서 가져온 데이터 전달함. ");
        getSetLobbyData.SetAccountData(lobbyData);

        Debug.Log("로그인 성공");

        displayMessage.Display(05);
    }
}
