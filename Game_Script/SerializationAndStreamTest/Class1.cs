using System;

[Serializable]
public class AccountStruct
{
    private string userID;
    private string userMACAddress;

    public AccountStruct(string userID = "", string userMACAddress = "")
    {
        this.userID = userID;
        this.userMACAddress = userMACAddress;
    }

    public string UserID { get; set; }

    public string UserMACAddress { get; set; }

}