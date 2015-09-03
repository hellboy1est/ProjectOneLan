<!DOCTYPE html>
<html>
<head>
<title>MAC Submit</title>
</head>
<body>

<h1>This is a Heading</h1>
<p>This is a paragraph.</p>


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
$mac=$_POST["macaddress"];
$username=$_POST["username"];
$str=strtoupper($mac);
$struser = strtoupper($username);

 
$sql = "INSERT INTO usermac (address,username)
VALUES ('$str','$struser')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>


</body>
</html>
