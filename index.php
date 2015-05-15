<html>
<head>
    <title>What The Fuck Should Lukas Eat For Lunch</title>
    <style>
        h1, h2, a {
            text-align: center;
            display: block;
        }

        footer {
            position: fixed;
            left: 0; bottom: 0;
        }

        footer, ul, li {
            list-style-type: none;
        }
    </style>
</head>
<body>
<h1>Lukas should fucking eat</h1>

<?php

/**
 * Created by IntelliJ IDEA.
 * User: Lukas
 * Date: 15.05.2015
 * Time: 14:07
 */

function gimmeAFuckingFoodArray() {
    $sandwiches = array(
        "a god fucking spicy avocado wrap",
        "a chicken fucking caesar wrap",
        "a fucking chicken bacon ranch sandwich",
        "a fucking chicken sandwich",
        "a fucking dragon sandwich",
    );

    $healthystuff = array(
        "a fucking lentil and carrot soup",
        "some god damn egg and rocket pizzas",
        "some cauliflower, paneer and fucking pea curry",
        "smoky beans on god fucking toast",
        "some fucking green fitters",
        "just something god fucking healthy",
        "just a god fucking apple",
        "a fucking chicken salad",
        "a fucking vegan salad",
        "a fucking salad"
    );

    $italianmode = array(
        "some fucking creamy pasta with asparagus and peas",
        "some fucking spaghetti",
        "a fucking handmade pizza",
    );

    $asianmode = array(
        "some chinease fucking eggplant",
        "some fucking sushi"
    );

    $minor = array(
        "grilled fucking cheese and fucking tomato soup",
        "a fucking indian curry nanburger",
        "some fucking tarragon chicken",
        "nothing just a fucking coffee",
        "god damn chicken tikka fucking masala",
        "a god fucking fish",
    );

    $things = array(
        $sandwiches,
        $italianmode,
        $asianmode,
        $healthystuff,
        $minor
    );

    return $things[array_rand($things)];
}

$randomArray = gimmeAFuckingFoodArray();
$randomFood = $randomArray[array_rand($randomArray)];

echo "<h2>" . $randomArray[array_rand($randomArray)] . "</h2>";

?>
<a href="?">Lukas doesn't fucking want that</a>

<footer>
    <ul>
        <li>2015 Copyright:</li>
        <li>
            <a href="//dotwee.de">
                <cite>Lukas Wolfsteiner</cite>
            </a>
        </li>
    </ul>
</footer>

</body>
</html>