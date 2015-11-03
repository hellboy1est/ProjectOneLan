<?php

			$host="localhost";
			$userMS="kakkr1";
			$passwordMS="1000017154";
			$database="kakkr1_IN612";

			$connection=mysqli_connect($host,$userMS,$passwordMS,$database) or die("Couldn't connect:". mysqli_error());
	
$selectquery="SELECT * FROM user";
$result=mysqli_query($connection,$selectquery);
//mysqli_query($connection,$selectquery);

 $array = mysqli_fetch_row($result);    
 echo json_encode($array);
mysqli_close($connection);
			
?>

CREATE TABLE data
(
id int NOT NULL AUTO_INCREMENT,
lName varchar(255) NOT NULL ,
fName varchar(255) NOT NULL,
bluetooth varchar(255),
timetable varchar(255),
image varchar(255),
PRIMARY KEY (id)
);