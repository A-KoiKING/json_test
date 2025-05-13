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
        // JSONファイルの準備
        JC = new JsonController<MyObject>("MyJson.json");

        string currentJsonPath = JC.filePath;

        filePathText.text = "ファイルパス : " + currentJsonPath;

        JC.InitializeJsonFile();

        // 色データ
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

