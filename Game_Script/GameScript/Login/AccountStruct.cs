using System;

namespace Account
{
    // ����ȭ�� �ϱ� ���ؼ��� �ش� Ŭ������ ����ȭ�� �����ϴٴ� ���� ����� �־�� �Ѵ�.
    [Serializable()]      // SerializableAttribute Ŭ���� �Ǵ� ISerializable �������̽� ����
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
}
