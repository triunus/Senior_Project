using System;

namespace AccountInfo
{
    // ����ȭ�� �ϱ� ���ؼ��� �ش� Ŭ������ ����ȭ�� �����ϴٴ� ���� ����� �־�� �Ѵ�.
    [Serializable]      // SerializableAttribute Ŭ���� �Ǵ� ISerializable �������̽� ����
    public class AccountData
    {
        private string userID;
        private string userMACAddress;

        public AccountData(string userID, string userMACAddress)
        {
            this.userID = userID;
            this.userMACAddress = userMACAddress;
        }

        public string UserID
        {
            get{ return userID; } 
        }

        public string UserMACAddress
        {
            get { return userMACAddress; }
        }
    }
}
