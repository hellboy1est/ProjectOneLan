<!DOCTYPE html>
<html>
<head>
<title>Add MAC Address</title>
<meta charset="UTF-8">
 <link rel="stylesheet" type="text/css" href="cssStyles.css">
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
 
 <script>
 $(function(){
 $('#submit').click(function(){
 var errors=false;
	if($('#macaddress').val() == ""){
		$('#macaddress').after('<span class="errors">Missing address</span>');
		errors=true;
		
	}
	if($('#username').val() == ""){
		$('#username').after('<span class="errors">Missing name</span>');
		errors=true;
		
	}
	if(errors==true){
		return false;
		}
		else{
		return true;
		}
 });
 
 
  });
 </script>
  
</head>
<body>
 
<form   action="insert-mac.php" method="post">
<fieldset>
		<legend >Add </legend>
  Mac address:<br>
  <input  type="text" name="macaddress">
  <br>
  User Name:<br>
   <input type="text" name="username">
  <br>
  <input id="btn" name="submit" type="submit" value="Submit">
  </fieldset>
</form>



</body>
</html>
