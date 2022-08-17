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
            // 기존 회원 정보 존재 메시지 출력.
            // 일단 제외하고 코드 작성.
            // 아마도, 회원가입 근처에 버튼 하나 생성 -> 회원가입을 원하면 해당 버튼을 클릭하고 다시 함.
            // if check == false일시, 회원가입 취소
            // if check == true일시, 기존 정보 삭제 진행.
            displayMessage.Display(01);
            if(!loginRegisterRequest.Delete(userData)) { return; }
        }

        userMACAddress = GetMACAddress();
        Debug.Log("02. Get userMACAddress : " + userMACAddress);

        userData = loginRegisterRequest.Register(userMACAddress);
        Debug.Log("03. Get userData At Server : " + userData + ", " + userData[0] + ", " + userData[1]);

        getSetAccountData.SetAccountData(userData);
        Debug.Log("04. Success Register");

        // 로그인 성공 : 02
        displayMessage.Display(02);

    }

    public string GetMACAddress()
    {
        Debug.Log("Get MAC Address");
        return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
    }
}
