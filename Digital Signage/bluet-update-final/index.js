//var app = require('http').createServer(handler)
//var io = require('socket.io')(app);
//var fs = require('fs');
//require module
//var Scanner = require("bluetooth-scanner");
// var a='';
 
// define input
//var device = "hci0";
//var mac=1;
//app.listen(80);

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
    	//sendMessage('add-device', mac,name); // actually send message to 		server
        //console.log("Sent new device", message);
	
    }); 
    bleScanner.on("done", function(msg){
      console.log(msg);
      main();
    }); 
}  

main();
 
   









