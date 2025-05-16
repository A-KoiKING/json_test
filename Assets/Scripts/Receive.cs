using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using MyClass;
using UniRx;

public class Receive : MonoBehaviour
{
    private UdpClient udpClient;
    private Subject<string> subject = new Subject<string>();
    private IPEndPoint ipEnd;

    [SerializeField] private GUIController guiController;

    void Start()
    {
        udpClient = new UdpClient(64276);
        udpClient.BeginReceive(OnReceived, udpClient);

        subject
            .ObserveOnMainThread()
            .Subscribe(json =>
            {
                try
                {
                    var receivedObj = JsonUtility.FromJson<MyObject>(json);
                    guiController.UpdateMyObject(receivedObj);
                }
                catch (Exception e)
                {
                    Debug.LogWarning("JSON Parse Error: " + e.Message);
                }
            }).AddTo(this);
    }

    private void OnReceived(IAsyncResult result)
    {
        UdpClient getUdp = (UdpClient)result.AsyncState;
        byte[] getByte = getUdp.EndReceive(result, ref ipEnd);

        var json = Encoding.UTF8.GetString(getByte);
        subject.OnNext(json);

        getUdp.BeginReceive(OnReceived, getUdp);
    }

    private void OnDestroy()
    {
        udpClient?.Close();
    }
}
