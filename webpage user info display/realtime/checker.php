<?php require('common.php');
//get current counter
$data['current'] = (int)$db->check_changes();
$check_counter=0;
//set initial value of update to false
$data['update'] = false;
//check if it's ajax call with POST containing current (for user) counter;
//and check if that counter is diffrent from the one in database,//checks if counter is empty
if(isset($_POST) && !empty($_POST['counter']) && (int)$_POST['counter']!=$check_counter){
	//the counters are diffrent so get new message list
	$data['news'] = 'Known Users';
	$data['news'] .= $db->get_news();
	$data['update'] = true;
 
}  
//just echo as JSON
echo json_encode($data);
/* End of file checker.php */
