<?php

function CreateFile($name){
    $my_file = $name;

    CreateData($my_file);
}

function CreateData($file){
    $handle = fopen($file, 'w') or die('Cannot open file:  '.$file);

    $data = array(
        'players' => array(
            array(
                'name' => "Player 1",
                'ip' => "10.4.43.21",
                'cards' => array(

                )
            )
        ),
        'deck' => array(

        ),
        'played' => array(

        ),
        'player turn' => 0, // id of the player
        'direction' => 0 // 0 means clockwise, 1 anti clockwise
    );
    $json_data = json_encode($data);
    fwrite($handle, $json_data);

    echo $data['players'][0]['name'];
}
