using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

class Program{
    static void Main(string[] args){
        subscribe();
    }
    static void subscribe(){
        // Create a new MqttClient object and connect to the broker
        MqttClient client = new MqttClient("broker.hivemq.com");

        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        //client.MqttMsgPublishReceived => It is a function to define which function call when a new message be publish(client_MqttMsgPublishReceived)
        client.Connect("Client2");//Connect to the MQTT Broker informing the client name

        // Subscribe to the "testingMQTT" topic and register a callback function to receive messages
        client.Subscribe(new string[] { "testingMQTT" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        // Callback function to handle received messages
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e){
            // Print the message to the console
            Console.WriteLine("Received message: " + Encoding.UTF8.GetString(e.Message));
        }
    }
    
}
