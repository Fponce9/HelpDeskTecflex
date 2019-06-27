<?php
// Please specify your Mail Server - Example: mail.example.com.
ini_set("SMTP","smtp.gmail.com");
// Please specify an SMTP Number 25 and 8889 are valid SMTP Ports.
ini_set("smtp_port","587");
// Please specify the return address to use
ini_set('sendmail_from', 'victorsahel180699@gmail.com');

ini_set('auth_password','caradecaca');
$to='u201616425@upc.edu.pe';
$subject ='CHUPAPINGA';
$message='<h1>Hi there,</h1><p>Thanks for testing</p>';
//Headers
$header = "From: The sender Name \r\n";
$header .="Reply-To: u201613429@upc.edu.pe\r\n";
$header .= "Content-type: text/html\r\n";

mail($to,$subject,$message);
?>