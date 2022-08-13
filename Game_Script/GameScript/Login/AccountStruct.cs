using System;

namespace Account
{
    // 직렬화를 하기 위해서는 해당 클래스가 직렬화가 가능하다는 것을 명시해 주어야 한다.
    [Serializable()]      // SerializableAttribute 클래스 또는 ISerializable 인터페이스 참고
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
