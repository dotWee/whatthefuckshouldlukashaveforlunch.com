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
    <h1>Lukas should have</h1>

    <?php

    /**
     * Created by IntelliJ IDEA.
     * User: Lukas
     * Date: 15.05.2015
     * Time: 14:07
     */

    function gimmeSomeFood()
    {
        $foods = file("foods.txt");
        return $foods[array_rand($foods)];
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