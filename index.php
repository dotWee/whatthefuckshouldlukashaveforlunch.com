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

    function remove_brackets($string)
    {
        return preg_replace('/\([^)]*\)|[()]/', '', $string);
    }

    function get_mensa_menu_url()
    {
        date_default_timezone_set('Europe/Berlin');
        $_weekNumber = intval(date("W"));

        return "http://www.stwno.de/infomax/daten-extern/csv/UNI-R/$_weekNumber.csv";
    }

    function get_menu()
    {
        $_csv = file_get_contents(get_mensa_menu_url());
        $_menuDate = date('d.m.Y');
        $_menuItems = array();

        foreach (explode("\n", $_csv) as $_row) {

            // parse csv row into a array separated by ;
            $_csvRow = explode(";", $_row);

            // get item from row
            $_rowItem = $_csvRow[3];

            // get date from row
            $_rowDate = $_csvRow[0];

            // put item into the menu array
            if ($_menuDate == $_rowDate) {
                $_menuItems[] = $_rowItem;
            }
        }

        return $_menuItems;
    }

    function get_content($_menu)
    {

        // return warning if menu is empty
        if (empty($_menu)) {
            return "<h1>Mensa seems closed!</h1>";

        } else {
            $_lunch_unformated = "<h1>Lukas should have</h1><h2>%s</h2><h1>for lunch.</h1>";

            // select random food from menu
            $_random_food = $_menu[array_rand($_menu)];

            // remove brackets from string
            $_random_food_cleared = remove_brackets($_random_food);

            // format string
            $_lunch_formated = sprintf($_lunch_unformated, $_random_food_cleared);

            // convert string from iso-8859-1 to utf-8
            $_lunch_encoded = utf8_encode($_lunch_formated);

            return $_lunch_encoded;
        }
    }

    function get_content_footer($_menu)
    {
        $_return_string = '<a href="?">%s</a>';
        if (empty($_menu)) {
            return sprintf($_return_string, "Refresh page");
        } else {
            return sprintf($_return_string, "Lukas doesn't fucking want that");
        }
    }

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