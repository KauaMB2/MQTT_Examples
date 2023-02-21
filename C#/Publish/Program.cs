using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

class Program{
    static void Main(string[] args){
        publish();
    }
    static void publish(){
        // Create a new MqttClient object and connect to the broker
        MqttClient client = new MqttClient("broker.hivemq.com");
        client.Connect("Client1");//Connect to the MQTT Broker informing the client name
        
        // Publish a message to the "testingMQTT" topic
        string message = "Hello, MQTT!";
        byte[] data = Encoding.UTF8.GetBytes(message);
        client.Publish("testingMQTT", data, (byte)MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        
        // Disconnect from the broker
        client.Disconnect();

        Console.WriteLine("Message published");
    }

}
