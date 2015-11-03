 /**
Socket(server.js) => Receives online users from socket client(index.js), compares them with devices stored in database and sends them to index.html
**/ 
 var http = require('http');
var app = http.createServer(handler)
var io = require('socket.io')(app);
var fs = require('fs');

// define input
var devices = "hci0";
//var mac=1;
app.listen(80);


function handler(req, res) {
    fs.readFile(__dirname + '/index.html',
        function(err, data) {
            if (err) {
                res.writeHead(500);
                return res.end('Error loading index.html');
            }

            res.writeHead(200);
            res.end(data);
        });
}

io.on('connection', function(socket) {
    socket.on('add-device', function(mac, name) {

        http.get("http://kate.ict.op.ac.nz/~kakkr1/connect_server.php?mac=" + mac, function(res) {
            res.setEncoding('utf8');
            res.on('data', function(data) {

                var jsonObject = JSON.parse(data); //parse
                for (var i = 0; i < jsonObject.length; i++) {

                    if (jsonObject[i].bluetooth == mac) {
                        console.log("match found = " + mac);

                        io.emit('news', jsonObject[i]); // send device to browsers
                        console.log('news', mac, name);

                    } else {
                        console.log("no match = " + mac);
                    }

                    console.log(jsonObject[i]);
                }

            });

        });

    });
});
