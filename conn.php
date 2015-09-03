<?php

try{
	$bdd=new PD0("mysql:host=localhost;dbname=getaddress","root","");
}catch(Exception $e){
	
	die ("Error " .$e->getMessage());
	
}

?>