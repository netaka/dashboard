using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mqtt;

public class MqttTest : MonoBehaviour
{
    Class1 mqttClient;
    public string host; 
    // Start is called before the first frame update
    void Start()
    {
        mqttClient = new Class1(host);
        mqttClient.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        var payload = mqttClient.GetPayload();
        print(payload);
        GetComponent<TextMesh>().text = payload;
    }
}
