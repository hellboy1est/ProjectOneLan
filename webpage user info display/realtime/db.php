<?php
/**
 * Class db for Ajax Auto Refresh - Volume II - demo
 *
 * @author Eliza Witkowska <kokers@codebusters.pl>
 * @link http://blog.codebusters.pl/en/entry/ajax-auto-refresh-volume-ii
 */
class db{

	/**
	 * db
	 *
	 * @var $	public $db;
	 */
	public $db;


	/**
	 * __construct
	 *
	 * @return void
	 */
	function __construct(){
		$this->db_connect('localhost','root','','getaddress');
	}


	/**
	 * db_connect
	 *
	 * Connect with database
	 *
	 * @param mixed $host
	 * @param mixed $user
	 * @param mixed $pass
	 * @param mixed $database
	 * @return void
	 */
	function db_connect($host,$user,$pass,$database){
		$this->db = new mysqli($host, $user, $pass, $database);

		if($this->db->connect_errno > 0){
			die('Unable to connect to database [' . $this->db->connect_error . ']');
		}
	}


	/**
	 * check_changes
	 *
	 * Get counter value from database
	 *
	 * @return void
	 */
	function check_changes(){
		$result = $this->db->query('SELECT counting FROM tblknown WHERE id=1');
		if($result = $result->fetch_object()){
			return $result->counting;
		}
		return 0;
	}


	/**
	 * register_changes
	 *
	 * Increase value of counter in database. Should be called everytime when
	 * something change (add,edit or delete)
	 *
	 * @return voids
	 */
	function register_changes(){
		$this->db->query('UPDATE news SET counting = counting + 1 WHERE id=33');
	}


	/**
	 * get_news
	 *
	 * Get list of news
	 *
	 * @return void
	 SELECT * FROM news WHERE id<>1 ORDER BY add_date DESC LIMIT 50
	 */
	function get_news(){
		if($result = $this->db->query('SELECT usermac.message,tblknown.name FROM usermac JOIN tblknown ON usermac.username = tblknown.name WHERE tblknown.id<>0' )){
			$return = '';
			while($r = $result->fetch_object()){
				$return .= '<p>Name: '.$r->name.' | '.htmlspecialchars($r->message).'</p>';
				$return .= '<hr/>';
			}
			return $return;
		}
	}


	/**
	 * add_news
	 *
	 * Add new message
	 *
	 * @param mixed $title
	 * @return void
	 */
	function add_news($title){
		$title = $this->db->real_escape_string($title);
		if($this->db->query('INSERT into news (title) VALUES ("'.$title.'")')){
			$this->register_changes();
			return TRUE;
		}
		return FALSE;
	}
}
/* End of file db.php */
