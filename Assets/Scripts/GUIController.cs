// GUIController.cs
using UnityEngine;
using UnityEngine.UI;
using MyClass;

public class GUIController : MonoBehaviour
{
    private MyObject myObject;

    [SerializeField] public Text loadDataText;

    private void Start()
    {
        myObject = new MyObject();
    }

    private void Update()
    {
        loadDataText.text = myObject.GetInfoString();
    }

    public void Click_RandomRGB()
    {
        myObject = MyObject.randomColorObject;
    }

    public void UpdateMyObject(MyObject newObj)
    {
        myObject = newObj;
    }
}
