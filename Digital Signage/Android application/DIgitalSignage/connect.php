<?php
$con = mysql_connect('mysql.hostinger.in', 'u600676282_rahul', 'againdead143');
mysql_select_db('u600676282_digit', $con);
$name=$_POST['name'];
$lname=$_POST['lname'];
$bluetooth="65fgf5" ;
$timetable="http://kate.ict.op.ac.nz/~kakkr1/joTime.png";
$image="http://kate.ict.op.ac.nz/~kakkr1/user123.png";


mysql_query("INSERT INTO data(bluetooth, fName, lName,timetable,image) VALUES ('{$bluetooth}', '{$name}', '{$lname}','{$timetable}','{$image}')");
mysql_close();
?>
CREATE TABLE user
(

fName varchar(255) NOT NULL,
lName varchar(255) NOT NULL

);