<?php

			$host="localhost";
			$userMS="kakkr1";
			$passwordMS="1000017154";
			$database="kakkr1_IN612";

			$connection=mysqli_connect($host,$userMS,$passwordMS,$database) or die("Couldn't connect:". mysqli_error());
	
$selectquery="SELECT * FROM data";
$result=mysqli_query($connection,$selectquery);
//mysqli_query($connection,$selectquery);
$rows = array();
 while($array = mysqli_fetch_assoc($result)){
$rows[] = $array ;


};    
 echo json_encode($rows);
mysqli_close($connection);
			
?>