<?php require('common.php');
if($_POST && !empty($_POST['title'])){
	$result = $db->add_news(strip_tags($_POST['title']));
}?>
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<title>Add news - Demo for Ajax Autorefresh</title>
</head>
<body>
	<h1>Ajax Auto Refresh </h1>
	<p>Open <a href="index.php">list of messages</a> in new window.<p>
	<?php if(isset($result)){
		if($result==TRUE){
			echo '<p>Success</p>';
		}else{
			echo '<p>Error</p>';
		}
	}else{?>
		<form method="post" action="#">
			<input type="text" name="title" size="50" />
			<input type="submit" value="Add message" />
		</form>
	<?php }?>
</body>
</html>

