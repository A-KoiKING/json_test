// GUIController.cs
using UnityEngine;
using UnityEngine.UI;
using MyClass;
using MyJsonControllerGenerics;

public class GUIController : MonoBehaviour
{
    private JsonController<MyObject> JC;
    private MyObject myObject;
    [SerializeField] public Text loadDataText;
    public Text filePathText;

    private void Start()
    {
        // JSON�t�@�C���̏���
        JC = new JsonController<MyObject>("MyJson.json");

        string currentJsonPath = JC.filePath;

        filePathText.text = "�t�@�C���p�X : " + currentJsonPath;

        JC.InitializeJsonFile();

        // �F�f�[�^
        myObject = JC.LoadJsonData();
    }

    private void Update()
    {
        JC.UpdateJsonFile(myObject);
        loadDataText.text = JC.LoadJsonData().GetInfoString();
    }

    public void Click_RandomRGB()
    {
        myObject = MyObject.randomColorObject;
    }
}

