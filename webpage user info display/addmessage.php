<!DOCTYPE html>
<html>
<head>
<title>Add Message</title>
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
if (isset($_POST['update']))
		{
     		processForm($conn);
			
		} 
		 else{
			 
			 showForm($conn);
		 }
		 function processForm($conn)
		{
			$name=$_POST['user'];
			$message=$_POST['message'];
			 
			
			// update data in mysql database 
$sql="UPDATE usermac SET message='$message' WHERE username='$name'" or die ("this");
$result=mysqli_query($conn,$sql) or die ("this stuffedup");
		echo"<b>Message added for:</b> <i>$name</i><br><b>Message:</b><i>$message</i>";
		}
?>
 
 
<?php 
function showForm($conn)
	
	{ 
 $self = htmlentities($_SERVER['PHP_SELF']);
echo("<form action = '$self' method='POST'><br>");

$sql = "SELECT username FROM usermac";
$result = $conn->query($sql); 
 $i=1.0;
 
 
 echo"<select name='user'>";
 
if ($result->num_rows > 0) {
	
     // output data of each row
     while($row = $result->fetch_assoc()) {
		 
		 
        echo "<option value=".$row['username'].">".$row['username']."</option><br>";
		
     } 
	 echo "<br>";	
	 
	 echo  "<input type='text' name='message'><br>";
	 
} else {
     echo "0 results";
	
	 
}
 
	 echo "</select>";
	 
	 echo"<input name='update' type='submit' ><br><br>";
	 
	
	 
	} 
	echo "</form>";
		
?>
 


<?php 
 $conn->close();
?>
</body>
</html>