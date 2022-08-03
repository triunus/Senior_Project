using AccountData;

using UnityEngine;

public class Login : MonoBehaviour
{
    GetSetAccountData getSetAccountData;
    string[] userDataInLocal;

    private void Awake()
    {
        getSetAccountData = new GetSetAccountData();
        userDataInLocal = new string[2];
    }

    public void LoginButtonOnClick()
    {
        userDataInLocal = getSetAccountData.GetAccountData();
        Debug.Log(userDataInLocal);

    }
}
