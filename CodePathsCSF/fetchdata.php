<?php
$ 
$sqlconn=mysqli_connect('localhost','root','', 'db_gereltuya')or die(mysql_error());


$dataquery=mysqli_query($sqlconn"select * from table_test");

$arr= array();

while ($r=mysqli_fetch_object($dataquery)){
array_push($arr,array("id_users"=> $r->id_users, "username"=>$r->username));

}

print_r(json_encode($arr));
?> 
