using GetSetAccountInfo;
using ConnectServer;

using System.Net.NetworkInformation;                    // MAC Address

using UnityEngine;

public class Register : MonoBehaviour
{
    private LoginRegisterRequest loginRegisterRequest;
    private GetSetAccountData getSetAccountData;

    private DisplayMessage displayMessage;

    string userMACAddress;
    string[] userData;

    private void Awake()
    {
        loginRegisterRequest = new LoginRegisterRequest();
        getSetAccountData = new GetSetAccountData();

        displayMessage = GetComponent<DisplayMessage>();

        userData = new string[2];
    }

    public void RegisterButtonOnClick()
    {
        Debug.Log("01. OnClicked Register Button");
        userData = getSetAccountData.GetAccountData();

        if(userData != null)
        {
            // ���� ȸ�� ���� ���� �޽��� ���.
            // �ϴ� �����ϰ� �ڵ� �ۼ�.
            // �Ƹ���, ȸ������ ��ó�� ��ư �ϳ� ���� -> ȸ�������� ���ϸ� �ش� ��ư�� Ŭ���ϰ� �ٽ� ��.
            // if check == false�Ͻ�, ȸ������ ���
            // if check == true�Ͻ�, ���� ���� ���� ����.
            displayMessage.Display(01);
            if(!loginRegisterRequest.Delete(userData)) { return; }
        }

        userMACAddress = GetMACAddress();
        Debug.Log("02. Get userMACAddress : " + userMACAddress);

        userData = loginRegisterRequest.Register(userMACAddress);
        Debug.Log("03. Get userData At Server : " + userData + ", " + userData[0] + ", " + userData[1]);

        getSetAccountData.SetAccountData(userData);
        Debug.Log("04. Success Register");

        // �α��� ���� : 02
        displayMessage.Display(02);

    }

    public string GetMACAddress()
    {
        Debug.Log("Get MAC Address");
        return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
    }
}
