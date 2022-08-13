using Account;

using UnityEngine;

// ���� ����ȭ�� �ʿ�.
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
                // Open�� � ü������ ���� ������ ������ �����մϴ�.
                // ������ �� �� �ִ��� ���δ� FileAccess ���������� ������ ���� ���� �޶����ϴ�.
                // ������ ������ FileNotFoundException ���ܰ� throw�˴ϴ�.
                Stream readInfo01 = new FileStream("./Assets/UncertifiedAccountData/UncertifiedInfo.txt",
                                                    FileMode.Open, FileAccess.Read, FileShare.Read);

                accountStruct = (AccountStruct)binaryFormatter.Deserialize(readInfo01);
                readInfo01.Close();

                // ������ ������ ���� ��, ID, MAC Address �� ��.
                Debug.Log("UncertifiedLogin03_2 : " + accountStruct.UserID);
            }
            catch (FileNotFoundException ex01)
            {
                // ���� ���� �ڵ� 21
                Debug.Log("UncertifiedLogin03_5");
                Debug.Log("Exception : " + ex01);
                // ȸ������ â���� �ȳ����ִ� ���� �޽���
            }
            return new string[] { accountStruct.UserID, accountStruct.UserMACAddress };
        }
    }
}
