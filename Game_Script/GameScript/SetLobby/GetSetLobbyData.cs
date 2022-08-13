using UnityEngine;

using LobbyInfo;

// ���� ����ȭ�� �ʿ�.
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GetSetLobbyInfo
{
    public class GetSetLobbyData
    {
        LobbyData lobbyData;
        IFormatter binaryFormatter;
        public void GetAccountData()
        {
            binaryFormatter = new BinaryFormatter();

            try
            {
                Debug.Log("GetAccountData ����.");
                // Open�� � ü������ ���� ������ ������ �����մϴ�.
                // ������ �� �� �ִ��� ���δ� FileAccess ���������� ������ ���� ���� �޶����ϴ�.
                // ������ ������ FileNotFoundException ���ܰ� throw�˴ϴ�.
                Stream readInfo = new FileStream("./Assets/usr/AccountData/AccountData.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

                lobbyData = (LobbyData)binaryFormatter.Deserialize(readInfo);
                readInfo.Close();

            }
            catch (FileNotFoundException error01)
            {
                // ���� ���� �ڵ� 21
                Debug.Log("���� ���� : " + error01);
            }

        }

        public void SetAccountData(string[] data)
        {
            binaryFormatter = new BinaryFormatter();

            try
            {
                Debug.Log("SetAccountData ����");
                // CreatNew�� � ü������ �� ������ ���鵵�� �����մϴ�. Write ������ �ʿ��մϴ�. ������ �̹� ������ IOException ���ܰ� throw�˴ϴ�.
                // Creat�� � ü������ �� ������ ���鵵�� �����մϴ�. Write ������ �ʿ��մϴ�. ������ �̹� ������ ����ϴ�. ����� ���� ������ ��� UnauthorizedAccessException ���ܰ� throw�˴ϴ�.
                Stream writeInfo = new FileStream("./Assets/usr/LobbyData/LobbyData.txt", FileMode.Create, FileAccess.Write, FileShare.None);

                // �������� ���� ������ ��ü�� ����.
                lobbyData = new LobbyData(data);
                Debug.Log("03. lobbyData : " + lobbyData + ", " + lobbyData.UserID + ", " + lobbyData.UserNickname + ", " + lobbyData.UserImage + ", " + lobbyData.FreeCoin + ", " + lobbyData.PayCoin + ", " + lobbyData.CharacterNumber);
                Debug.Log("03-1 lobbyData.SkillNumber : " + lobbyData.SkillNumber + ", " + lobbyData.SkillNumber[0] + ", " + lobbyData.SkillNumber[1]);

                // ���� ���Ϸ� ����ȭ ����
                binaryFormatter.Serialize(writeInfo, lobbyData);

                writeInfo.Close();
                Debug.Log("Write Complete");
            }
            catch (UnassignedReferenceException error01)
            {
                Debug.Log(error01);
            }
        }
    }
}
