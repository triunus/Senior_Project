using System;

namespace LobbyInfo
{
    [Serializable]
    public class LobbyData
    {
        private string userID;
        private string userNickname;
        private int userImage;
        private int freeCoin;
        private int payCoin;
        private int characterNumber;
        private int[] skillNumber;

        public LobbyData(string[] lobbyData)
        {
            this.userID = lobbyData[0];
            this.userNickname = lobbyData[1];
            this.userImage = Int32.Parse(lobbyData[2]);
            this.freeCoin = Int32.Parse(lobbyData[3]);
            this.payCoin = Int32.Parse(lobbyData[4]);
            this.characterNumber = Int32.Parse(lobbyData[5]);
            SetSkillNumber(lobbyData);
        }
        
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string UserNickname
        {
            get { return userNickname; }
            set { userNickname = value; }
        }
        public int UserImage
        {
            get { return userImage; }
            set { userImage = value; }
        }
        public int FreeCoin
        {
            get { return freeCoin; }
            set { freeCoin = value; }
        }
        public int PayCoin
        {
            get { return payCoin; }
            set { payCoin = value; }
        }
        public int CharacterNumber
        {
            get { return characterNumber; }
            set { characterNumber = value; }
        }
        public int[] SkillNumber
        {
            get { return skillNumber; }
        }

        public void SetSkillNumber(string[] lobbyData)
        {
            skillNumber = new int[lobbyData.Length - 6];

            for(int i=0; i< skillNumber.Length; i++)
            {
                skillNumber[i] = Int32.Parse(lobbyData[6 + i]);
            }
        }
    }
}
