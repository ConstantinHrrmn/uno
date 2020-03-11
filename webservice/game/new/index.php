<?php

include 'newgame.php';

if(isset($_GET['code'])){
    $path = "../files/".$_GET['code'].".txt";
    if(file_exists($path)){
        echo json_encode("Already exists");
    }else{
        CreateFile($path);
        echo json_encode( "Game ".$_GET['code']." created !");
    }
}