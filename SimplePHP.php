//Program Segment P1:
<?php
if ($_POST['user_name']) {
	print("Welcome, ");
	print($_POST['user_name']);
}
else {
	print <<<_HTML_
	<FORM method="post" action = "$_SERVER['PHP_SELF']">
	Enter your name: <input type = "text" name = "user_name"
	<br/>
	<INPUT type = "submit" value = "SUBMIT NAME">
	</FORM>
	_HTML_;
}
?>
