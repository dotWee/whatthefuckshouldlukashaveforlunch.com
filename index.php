<!DOCTYPE html>
<head lang="en">
    <title>What The Fuck Should Lukas Eat For Lunch</title>
    <link rel="shortcut icon" href="favicon.png">
    <meta charset="utf-8">
    <meta name=viewport content="width=device-width, initial-scale=1">
    <style>
        html, body {
            font-family: "Times New Roman", Times, serif;
            letter-spacing: 0.01rem;
            text-align: center;
            overflow: hidden;
            padding: 0;
            margin: 0;

            height: 100%;
            width: 100%;
        }

        section * {
            display: block;
        }

        section {
            position: relative;
            top: 50%;

            -webkit-transform: translateY(-50%);
            -moz-transform: translateY(-50%);
            -ms-transform: translateY(-50%);
            -o-transform: translateY(-50%);
            transform: translateY(-50%);
            margin: 0 auto;

            max-width: 25rem;
            min-width: 12rem;
            width: 70%;
        }

        section a {
            line-height: 120%;
        }

        h1 {
            font-size: 3rem;
            margin: 0;
        }

        h2 {
            font-size: 2rem;
            margin: 1em;
        }

        footer {
            white-space: nowrap;
            left: 0;
            bottom: 0;
            position: fixed;
            padding: 0;
            margin: 1em;
        }

        footer a, footer p {
            font-size: 1rem;
            text-align: left;
            margin: 0.1em;
            padding: 0;
        }

        footer a {
            font-style: italic;
        }
    </style>
</head>
<body>

<section>
    <h1>Lukas should eat</h1>

    <?php

    /**
     * Created by IntelliJ IDEA.
     * User: Lukas
     * Date: 15.05.2015
     * Time: 14:07
     */

    function gimmeSomeFood()
    {

        $stuff = array(
            "a fucking spicy avocado wrap",
            "a chicken fucking caesar wrap",
            "a fucking chicken bacon ranch sandwich",
            "a fucking chicken sandwich",
            "a fucking dragon sandwich",
            "a fucking lentil and carrot soup",
            "a fucking chicken salad",
            "a fucking vegan salad",
            "a fucking salad",
            "a wrap with fucking couscous, beans and rosted pepper",
            "a fucking indian curry nanburger",
            "a fucking margharita pizza",
            "a fucking pepperoni pizza",
            "a fucking handmade pizza",
            "a fucking tokachi wagyu steak",

            "smoky beans on damn fucking toast",
            "just something damn fucking healthy",
            "just a damn fucking apple",
            "grilled fucking cheese and fucking tomato soup",
            "nothing just a fucking coffee",

            "some cauliflower, paneer and fucking pea curry",
            "some damn chicken tikka fucking masala",
            "some fucking tarragon chicken",
            "some fucking creamy pasta with asparagus and peas",
            "some fucking spaghetti",
            "some chinease fucking eggplant",
            "some fucking sushi",
            "some fucking chicken black bean chili",
            "some fucking sweet potato pasta",
            "some fucking zimbabwan peanut stew",
            "some fucking enchiladas suizas",
            "some chicken with smashed potatoes and fucking broccoli"
        );

        return array_rand($stuff);
    }

    echo "    <h2>" . gimmeSomeFood() . "</h2>";

    ?>

    <h1>for lunch.</h1>

    <a href="?">Lukas doesn't fucking want that</a>
</section>

<footer>
    <p>2015, <a href="https://dotwee.de">Lukas Wolfsteiner</a></p>

    <p>whatthefuckshouldlukashaveforlunch on <a href="https://github.com/dotWee/whatthefuckshouldlukashaveforlunch.com">Github</a>
    </p>
</footer>

</body>
</html>