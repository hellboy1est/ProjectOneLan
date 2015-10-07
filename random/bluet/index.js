//require module
var Scanner = require("bluetooth-scanner");

// define input
var device = "hci0";


function main()
{

	// Scan for devices
	var bleScanner = new Scanner(device);

	bleScanner.on("device",function(mac, name) {
		  console.log('Found device: ', name, ' with MAC: ', mac);
	});

	bleScanner.on("done", function(msg){
		console.log(msg);
		main();
	});


}

main();
