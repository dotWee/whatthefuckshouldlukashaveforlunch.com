<?php
/**
 * Created by IntelliJ IDEA.
 * User: lukas
 * Date: 24.02.17
 * Time: 18:30
 */

function remove_brackets($string)
{
    return preg_replace('/\([^)]*\)|[()]/', '', $string);
}

function get_mensa_menu_url()
{
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