using System;
using UnityEngine;

// 서버
using ServerInfomation;
using System.Net;

// (직렬화된)파일 읽고쓰기
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
            // GetURL함수를 이용하여 로그인과 나눠 사용.
            // 뒤에 붙는 값을 변경하여, 서버에서 수행하는 행동?을 결정.
            url = string.Format("{0}{1}", server.GetURL(), "/register_test");

            WebRequest request = WebRequest.Create(url);

            // 이 앞의 코드에 대한 설명은, CShapStudy/ChsapStudy08/Program08.cs를 참조하자.
            request.Method = "POST";

            // data는 key=value&key=value 형식으로 저장한다.
            string requestData = "MACAddress="+MACAddress;
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            // 전달하고자 하는 내용을 Request Stream에 기입.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // 지정된 요청 형식으로 응답 요청.
            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // System.IO.StreamReader Class : 특정 인코딩의 바이트 스트림에서 문자를 읽는 TextReader 를 구현합니다.
                // 매개변수로 받은 스트림을 읽습니다.
                StreamReader reader = new StreamReader(dataStream);

                // 현재 위치부터 스트림 끝까지의 모든 문자를 읽는다.
                responseFromServer = reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
                Console.ReadLine();
            }

            response.Close();

            return ReturnValueParse(responseFromServer);
        }

        public string[] Login(string[] UserDataInLocal)
        {
            // GetURL함수를 이용하여 로그인과 나눠 사용.
            // 뒤에 붙는 값을 변경하여, 서버에서 수행하는 행동?을 결정.
            url = string.Format("{0}{1}", server.GetURL(), "/login_test");

            WebRequest request = WebRequest.Create(url);

            // 이 앞의 코드에 대한 설명은, CShapStudy/ChsapStudy08/Program08.cs를 참조하자.
            request.Method = "POST";

            // data는 key=value&key=value 형식으로 저장한다.
            string requestData = "userID=" + UserDataInLocal[0] + "&userPW=" + UserDataInLocal[1];
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            // 전달하고자 하는 내용을 Request Stream에 기입.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // 지정된 요청 형식으로 응답 요청.
            WebResponse response = request.GetResponse();

            Debug.Log(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // System.IO.StreamReader Class : 특정 인코딩의 바이트 스트림에서 문자를 읽는 TextReader 를 구현합니다.
                // 매개변수로 받은 스트림을 읽습니다.
                StreamReader reader = new StreamReader(dataStream);

                // 현재 위치부터 스트림 끝까지의 모든 문자를 읽는다.
                responseFromServer = reader.ReadToEnd();

                Debug.Log(responseFromServer);
            }

            response.Close();

            return ReturnValueParse(responseFromServer);
        }

        public bool Delete(string[] UserDataInLocal)
        {
            // GetURL함수를 이용하여 로그인과 나눠 사용.
            // 뒤에 붙는 값을 변경하여, 서버에서 수행하는 행동?을 결정.
            url = string.Format("{0}{1}", server.GetURL(), "/delete_test");

            WebRequest request = WebRequest.Create(url);

            // 이 앞의 코드에 대한 설명은, CShapStudy/ChsapStudy08/Program08.cs를 참조하자.
            request.Method = "POST";

            // data는 key=value&key=value 형식으로 저장한다.
            string requestData = "userID=" + UserDataInLocal[0] + "&userPW=" + UserDataInLocal[1];
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            // 전달하고자 하는 내용을 Request Stream에 기입.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // 지정된 요청 형식으로 응답 요청.
            WebResponse response = request.GetResponse();

            Debug.Log(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                // System.IO.StreamReader Class : 특정 인코딩의 바이트 스트림에서 문자를 읽는 TextReader 를 구현합니다.
                // 매개변수로 받은 스트림을 읽습니다.
                StreamReader reader = new StreamReader(dataStream);

                // 현재 위치부터 스트림 끝까지의 모든 문자를 읽는다.
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
                // Open은 운영 체제에서 기존 파일을 열도록 지정합니다. 파일을 열 수 있는지 여부는 FileAccess 열거형에서 지정된 값에 따라 달라집니다.
                // 파일이 없으면 FileNotFoundException 예외가 throw됩니다.
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
