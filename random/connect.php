xml_error_string<?php
$con = mysql_connect('mysql.hostinger.in', 'u600676282_rahul', 'againdead143');
mysql_select_db('u600676282_digit', $con);
$name="asas";
$lname="hjhk";
 

mysql_query("INSERT INTO user(fName, lName) VALUES ('{$name}', '{$lname}')");
mysql_close();
?>