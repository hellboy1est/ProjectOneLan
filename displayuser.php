<!DOCTYPE html>
<html>
<head>
<title>Welcome User</title>
</head>
<body>

<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "getaddress";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
     die("Connection failed: " . $conn->connect_error);
} 


$sqlknown = "SELECT usermac.message,tblknown.name FROM usermac JOIN tblknown ON usermac.username = tblknown.name WHERE usermac.message IS NOT NULL";
$result = $conn->query($sqlknown);

 
if ($result->num_rows > 0) {
	
     // output data of each row
     while($row = $result->fetch_assoc()) {
         echo "<br> message: ". $row["message"]. " - username: ". $row["name"].  "<br>";
     }
} else {
     echo "0 results";
}

$conn->close();
?>  

</body>
</html>