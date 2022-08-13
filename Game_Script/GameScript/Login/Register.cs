using GetSetAccountInfo;
using ConnectServer;

using System.Net.NetworkInformation;                    // MAC Address

using UnityEngine;

public class Register : MonoBehaviour
{
    LoginRegisterRequest loginRegisterRequest;
    GetSetAccountData getSetAccountData;

    string userMACAddress;
    string[] userData;

    private void Awake()
    {
        loginRegisterRequest = new LoginRegisterRequest();
        getSetAccountData = new GetSetAccountData();
        userData = new string[2];
    }

    public void RegisterButtonOnClick()
    {
        Debug.Log("01. OnClicked Register Button");
        userData = getSetAccountData.GetAccountData();

        if(userData != null)
        {
            // ���� ȸ�� ���� ���� �޽��� ���.
            // if check == false�Ͻ�, ȸ������ ���
            // if check == true�Ͻ�, ���� ���� ���� ����.

            if(!loginRegisterRequest.Delete(userData)) { return; }
        }

        userMACAddress = GetMACAddress();
        Debug.Log("02. Get userMACAddress : " + userMACAddress);

        userData = loginRegisterRequest.Register(userMACAddress);
        Debug.Log("03. Get userData At Server : " + userData + ", " + userData[0] + ", " + userData[1]);

        getSetAccountData.SetAccountData(userData);
        Debug.Log("04. Success Register");
    }

    public string GetMACAddress()
    {
        Debug.Log("Get MAC Address");
        return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
    }
}
