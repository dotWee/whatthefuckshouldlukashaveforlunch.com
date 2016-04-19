<!DOCTYPE html>
<html lang="en">
<head>
    <title>What The Fuck Should Lukas Eat For Lunch</title>
    <link rel="shortcut icon" href="favicon.png">
    <meta charset="utf-8">

    <!-- Search engine control -->
    <meta name="robots" content="index, follow">
    <meta name="description" content="Coding'n personal stuff">
    <meta name="author" content="Lukas Wolfsteiner">
    <meta name="publisher" content="Lukas Wolfsteiner">
    <meta name="copyright" content="Lukas Wolfsteiner">
    <link rel="canonical" href="https://dotwee.de/">
    <meta name="keywords"
          content="Wolfsteiner, Lukas, Lukas Wolfsteiner, Lukas dotwee Wolfsteiner, dotwee, dot, wee, coding, wee coding, dotwee coding">

    <!-- Layout management -->
    <meta name="theme-color" content="#444444">
    <meta name="HandheldFriendly" content="True">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">

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
            margin: 0.8rem;
        }

        footer > * {
            font-family: "Lucida Console", Monaco, monospace;
            font-size: 0.80rem;
            text-align: left;
            margin: 0.05em;
            padding: 0;
        }
    </style>

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date();
            a = s.createElement(o),
                m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-58602415-5', 'auto');
        ga('send', 'pageview');

    </script>
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
        $foods = file("foods.txt", FILE_SKIP_EMPTY_LINES);
        return $foods[array_rand($foods)];
    }

    echo "    <h2>" . gimmeSomeFood() . "</h2>";

    ?>

    <h1>for lunch.</h1>

    <a href="?">Lukas doesn't fucking want that</a>
</section>

<footer>
    <p>2016, <a href="https://dotwee.de">Lukas Wolfsteiner</a></p>

    <p>whatthefuckshouldlukashaveforlunch on <a href="https://github.com/dotWee/whatthefuckshouldlukashaveforlunch.com">Github</a>
    </p>
</footer>

</body>
</html>