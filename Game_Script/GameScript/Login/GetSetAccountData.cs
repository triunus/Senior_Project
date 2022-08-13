using Account;

using UnityEngine;

// 이진 직렬화에 필요.
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace AccountData
{
    public class GetSetAccountData
    {
        AccountStruct accountStruct;
        IFormatter binaryFormatter;
        public string[] GetAccountData()
        {
            binaryFormatter = new BinaryFormatter();

            try
            {
                Debug.Log("UncertifiedLogin03_1");
                // Open은 운영 체제에서 기존 파일을 열도록 지정합니다.
                // 파일을 열 수 있는지 여부는 FileAccess 열거형에서 지정된 값에 따라 달라집니다.
                // 파일이 없으면 FileNotFoundException 예외가 throw됩니다.
                Stream readInfo01 = new FileStream("./Assets/UncertifiedAccountData/UncertifiedInfo.txt",
                                                    FileMode.Open, FileAccess.Read, FileShare.Read);

                accountStruct = (AccountStruct)binaryFormatter.Deserialize(readInfo01);
                readInfo01.Close();

                // 서버에 데이터 전송 후, ID, MAC Address 값 비교.
                Debug.Log("UncertifiedLogin03_2 : " + accountStruct.UserID);
            }
            catch (FileNotFoundException ex01)
            {
                // 파일 없음 코드 21
                Debug.Log("UncertifiedLogin03_5");
                Debug.Log("Exception : " + ex01);
                // 회원가입 창으로 안내해주는 유도 메시지
            }
            return new string[] { accountStruct.UserID, accountStruct.UserMACAddress };
        }
    }
}
