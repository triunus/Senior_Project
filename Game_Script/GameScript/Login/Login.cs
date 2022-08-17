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

            Debug.Log("02-1. ������ ��� userData�� null����.");
            displayMessage.Display(03);
            return;
        }
        Debug.Log("02. userData : " + userData + ", " + userData[0] + ", " + userData[1]);

        lobbyData = loginRegisterRequest.Login(userData);
        Debug.Log("03. lobbyData : " + lobbyData + ", " + lobbyData[0] + ", " + lobbyData[1] + ", " + lobbyData[2] + ", " + lobbyData[3] + ", " + lobbyData[4]);

        Debug.Log("LoginButtonOnClick04 : �κ� ������ �����Ϸ�, �������� ������ ������ ������. ");
        getSetLobbyData.SetAccountData(lobbyData);

        Debug.Log("�α��� ����");

        displayMessage.Display(05);
    }
}
