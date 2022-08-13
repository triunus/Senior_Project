using System;
using UnityEngine;

// ����
using ServerInfomation;
using System.Net;

// (����ȭ��)���� �а���
/*using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;*/

using System.IO;
using System.Text;

namespace ConnectServer
{
    public class LoginRegisterRequest
    {
        ServerInfo server = new ServerInfo();
        string responseFromServer;
        string url;

        public string[] Register(string MACAddress)
        {
            // GetURL�Լ��� �̿��Ͽ� �α��ΰ� ���� ���.
            // �ڿ� �ٴ� ���� �����Ͽ�, �������� �����ϴ� �ൿ?�� ����.
            url = string.Format("{0}{1}", server.GetURL(), "/register_test");

            WebRequest request = WebRequest.Create(url);

            // �� ���� �ڵ忡 ���� ������, CShapStudy/ChsapStudy08/Program08.cs�� ��������.
            request.Method = "POST";

            // data�� key=value&key=value �������� �����Ѵ�.
            string requestData = "MACAddress="+MACAddress;
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            // �����ϰ��� �ϴ� ������ Request Stream�� ����.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // ������ ��û �������� ���� ��û.
            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // System.IO.StreamReader Class : Ư�� ���ڵ��� ����Ʈ ��Ʈ������ ���ڸ� �д� TextReader �� �����մϴ�.
                // �Ű������� ���� ��Ʈ���� �н��ϴ�.
                StreamReader reader = new StreamReader(dataStream);

                // ���� ��ġ���� ��Ʈ�� �������� ��� ���ڸ� �д´�.
                responseFromServer = reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
                Console.ReadLine();
            }

            response.Close();

            return ReturnValueParse(responseFromServer);
        }

        public string[] Login(string[] UserDataInLocal)
        {
            // GetURL�Լ��� �̿��Ͽ� �α��ΰ� ���� ���.
            // �ڿ� �ٴ� ���� �����Ͽ�, �������� �����ϴ� �ൿ?�� ����.
            url = string.Format("{0}{1}", server.GetURL(), "/login_test");

            WebRequest request = WebRequest.Create(url);

            // �� ���� �ڵ忡 ���� ������, CShapStudy/ChsapStudy08/Program08.cs�� ��������.
            request.Method = "POST";

            // data�� key=value&key=value �������� �����Ѵ�.
            string requestData = "userID=" + UserDataInLocal[0] + "&userPW=" + UserDataInLocal[1];
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            // �����ϰ��� �ϴ� ������ Request Stream�� ����.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // ������ ��û �������� ���� ��û.
            WebResponse response = request.GetResponse();

            Debug.Log(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // System.IO.StreamReader Class : Ư�� ���ڵ��� ����Ʈ ��Ʈ������ ���ڸ� �д� TextReader �� �����մϴ�.
                // �Ű������� ���� ��Ʈ���� �н��ϴ�.
                StreamReader reader = new StreamReader(dataStream);

                // ���� ��ġ���� ��Ʈ�� �������� ��� ���ڸ� �д´�.
                responseFromServer = reader.ReadToEnd();

                Debug.Log(responseFromServer);
            }

            response.Close();

            return ReturnValueParse(responseFromServer);
        }

        public bool Delete(string[] UserDataInLocal)
        {
            // GetURL�Լ��� �̿��Ͽ� �α��ΰ� ���� ���.
            // �ڿ� �ٴ� ���� �����Ͽ�, �������� �����ϴ� �ൿ?�� ����.
            url = string.Format("{0}{1}", server.GetURL(), "/delete_test");

            WebRequest request = WebRequest.Create(url);

            // �� ���� �ڵ忡 ���� ������, CShapStudy/ChsapStudy08/Program08.cs�� ��������.
            request.Method = "POST";

            // data�� key=value&key=value �������� �����Ѵ�.
            string requestData = "userID=" + UserDataInLocal[0] + "&userPW=" + UserDataInLocal[1];
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            // �����ϰ��� �ϴ� ������ Request Stream�� ����.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // ������ ��û �������� ���� ��û.
            WebResponse response = request.GetResponse();

            Debug.Log(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // System.IO.StreamReader Class : Ư�� ���ڵ��� ����Ʈ ��Ʈ������ ���ڸ� �д� TextReader �� �����մϴ�.
                // �Ű������� ���� ��Ʈ���� �н��ϴ�.
                StreamReader reader = new StreamReader(dataStream);

                // ���� ��ġ���� ��Ʈ�� �������� ��� ���ڸ� �д´�.
                responseFromServer = reader.ReadToEnd();

                Debug.Log(responseFromServer);
            }

            response.Close();

            return Convert.ToBoolean(responseFromServer);
        }

        public string[] ReturnValueParse(string responseFromServer)
        {
            char[] delimiter = { ' ', ',', '[', ']' };
            string[] tmp = responseFromServer.Split(delimiter);

            string[] value = new string[tmp.Length - 2];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = tmp[i + 1];
            }

            Debug.Log(value);
            return value;
        }

        /*public string GetURL()
        {
            IFormatter formatter = new BinaryFormatter();
            ServerInfo server;

            string serverInfo = null;

            try
            {
                // Open�� � ü������ ���� ������ ������ �����մϴ�. ������ �� �� �ִ��� ���δ� FileAccess ���������� ������ ���� ���� �޶����ϴ�.
                // ������ ������ FileNotFoundException ���ܰ� throw�˴ϴ�.
                Stream readInfo = new FileStream("./Assets/srv/Server/ServerData.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

                server = (ServerInfo)formatter.Deserialize(readInfo);

                readInfo.Close();
                serverInfo = server.GetURI();

                Console.WriteLine(server.GetURI());
                Console.ReadLine();
            }
            catch (FileNotFoundException error01)
            {
                Console.WriteLine("Error : " + error01);
                Console.ReadLine();
            }

            return serverInfo;
        }*/


    }

}
