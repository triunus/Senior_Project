using UnityEngine;
using TMPro;
using ChangeSceneManager;

using System;
using System.IO;
using System.Data;

using Newtonsoft.Json;


public class DisplayMessage : MonoBehaviour
{
    [SerializeField]
    private RectTransform messagePanel;

    [SerializeField]
    private TextMeshProUGUI meesageTitle;
    [SerializeField]
    private TextMeshProUGUI meesageContent;

    private ChangeScene changeScene;
    private int code;

    private void Awake()
    {
        changeScene = new ChangeScene();
    }


    public void Display(int codeNumber)
    {
        code = codeNumber;
        FindCode(code);

        messagePanel.gameObject.SetActive(true);
    }

    public void MesageCheckButtonOnClick()
    {
        if (code == 05)
        {
            ChangeScence();
            return;
        }

        messagePanel.gameObject.SetActive(false);
    }

    public void ChangeScence()
    {
        changeScene.SceneLoader("GameLobbyScene");
    }

    public void FindCode(int codeNumber)
    {
        DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(File.ReadAllText("./Assets/err/MessageCode.json"));

        for(int i = 0; i < dataTable.Rows.Count; i++)
        {
            if(Convert.ToInt32(dataTable.Rows[i][0]) == codeNumber)
            {
                meesageTitle.text = Convert.ToString(dataTable.Rows[i][1]);
                meesageContent.text = Convert.ToString(dataTable.Rows[i][2]);

                Debug.Log(dataTable.Rows[i][0] + ", " + dataTable.Rows[i][1] + ", " + dataTable.Rows[i][2]);
                break;
            }
        }
    }
}
