using System;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        AccountStruct accountStruct = new AccountStruct();
        IFormatter binaryFormatter_read = new BinaryFormatter();
        IFormatter BinaryFormatter_write = new BinaryFormatter();

        try
        {
            // Open은 운영 체제에서 기존 파일을 열도록 지정합니다.
            // 파일을 열 수 있는지 여부는 FileAccess 열거형에서 지정된 값에 따라 달라집니다.
            // 파일이 없으면 FileNotFoundException 예외가 throw됩니다.
            Stream readInfo = new FileStream("./test.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

            accountStruct = (AccountStruct)binaryFormatter_read.Deserialize(readInfo);
            readInfo.Close();

            Console.WriteLine("UserID : " + accountStruct.UserID);
            Console.WriteLine("UserID : " + accountStruct.UserMACAddress);
            Console.ReadLine();
        }
        catch (FileNotFoundException ex01)
        {
            Console.WriteLine("Exception : " + ex01);

            try
            {
                accountStruct.UserID = "Triunus";
                accountStruct.UserMACAddress = "TriunusMACAddress";

                Stream writeinfo = new FileStream("./test.txt", FileMode.Create, FileAccess.Write, FileShare.None);

                BinaryFormatter_write.Serialize(writeinfo, accountStruct);

                writeinfo.Close();
            }
            catch(UnauthorizedAccessException ex02)
            {
                Console.WriteLine("Exception : " + ex02);
            }
        }
    }
}
