const mqtt = require('mqtt')
const host = 'broker.emqx.io'
const port = '1883'
const clientId = `ngngng`
const connectUrl = `ws://broker.hivemq.com:8000/mqtt`

var i=0

const client = mqtt.connect(connectUrl, {
  clientId,
  clean: true,
  username: 'Publisher',
  password: 'public',
})

const topic = 'myTopic'
client.on('connect', () => {//inicia conexão
  console.log('Connected')
  sendMessage()
})
const sendMessage=()=>{
  client.subscribe('myTopic', function (err) {//Tenta fazer um subscribe no tópico
    if (!err && i<10) {//Se não deu erro...
      x=Math.floor(Math.random() * (100 - 0 + 1) + 0).toString()//Gera valor aleatório
      client.publish('myTopic', x)//Publica no tópico
      console.log(x)
    }
  })
}
  

client.on('message', (topic, message) => {//Pega a mensagem no tópico
  console.log('Mensagem recebida!\nTópico:', topic, "\nMensagem:",message.toString())//Exibe mensagem na tela
  i++
  sendMessage()
})

