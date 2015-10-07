<?php require('common.php'); ?>
<!DOCTYPE html>
<html>
<head>

<title>Digital Signage</title>
<meta name="viewport" content="width=device-width,initial-scale=1.0">
<link rel="stylesheet" type="text/css" href="css/style.css"> 
<link rel="stylesheet" type="text/css" href="css/custom.css"> 
 
 

 <link rel="stylesheet" type="text/css" href="css/home.css">
	<script src="jquery-1.10.2.min.js"></script>
	<script>
		/* AJAX request to checker */
		function check(){
			$.ajax({
				type: 'POST',
				url: 'checker.php',
				dataType: 'json',
				data: {
					counter:$('#message-list').data('counter')
				}
			}).done(function( response ) {
				/* update counter */
				$('#message-list').data('counter',response.current);
				/* check if with response we got a new update */
				if(response.update==true){
					$('#message-list').html(response.news);
				}
			});
		}
		//Every 20 sec check if there is new update
		setInterval(check,2000);
	</script>
</head>
<body>
	  
<div class="navbar navbar-default navbar-fixed-top">
 
 
 <div class="navbar-header">
<!--add nav title -->
  <a class="navbar-brand" id="aa" >Digital Signage</a>
<!--adds button when small screen -->
   
   </div>	
   </div>
   <br><br>
 <div class="container "> <br><br>
	<?php /* Our message container. data-counter should contain initial value of couner from database */ ?>
	<div id="message-list" data-counter="<?php echo (int)$db->check_changes();?>">
		<?php
		
		?>
		<span class="label label-success"><?php echo $db->get_news();
		  
		?></span>  
	</div>
 </div>	
</body>  
</html>

