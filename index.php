<?php

// Disable cache using custom header
header("Cache-Control: no-store, no-cache, must-revalidate, max-age=0");
header("Cache-Control: post-check=0, pre-check=0", false);
header("Pragma: no-cache");

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>What The Fuck Should Lukas Have For Lunch</title>
    <link rel="shortcut icon" href="favicon.png">
    <link rel="stylesheet" href="css/style.css">
    <meta charset="utf-8">

    <!-- Search engine control -->
    <meta name="robots" content="index, follow">
    <meta name="description" content="What The Fuck Should Lukas Have For Lunch">
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
    <?php

    /**
     * Created by IntelliJ IDEA.
     * User: Lukas
     * Date: 15.05.2015
     * Time: 14:07
     */

    date_default_timezone_set('Europe/Berlin');
    include_once "lib/api.php";

    $_menu = get_menu();
    echo get_content($_menu);
    echo get_content_footer($_menu);

    ?>


</section>

<footer>
    <p><?php echo date("Y"); ?>, <a href="https://dotwee.de">Lukas Wolfsteiner</a></p>

    <p>(Universität Regensburg Mensa Edition)</p>
    <p>whatthefuckshouldlukashaveforlunch on <a href="https://github.com/dotWee/whatthefuckshouldlukashaveforlunch.com">Github</a>
    </p>
</footer>

</body>
</html>