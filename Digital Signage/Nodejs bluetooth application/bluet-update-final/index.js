/**
Socket client(index.js) => Runs bluetooth scanner and sends devices to server.js
**/ 

var port = 80,
    devices = "hci0",
    socket = require('socket.io-client')('http://localhost:'+port);
    Scanner = require("bluetooth-scanner");
  
function main()
{
    var bleScanner = new Scanner(devices);
    bleScanner.on("device",function(mac, name) {
     	console.log('Found device: ', name, ' with MAC: ', mac);
    	//var message = {'address': mac, 'name': name}; // prepare message
			socket.emit('add-device', mac, name); 
	
    }); 
    bleScanner.on("done", function(msg){
      console.log(msg);
      main();
    }); 
}  

main();
 
   









