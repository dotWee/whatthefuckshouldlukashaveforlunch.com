<?php include "lib/header.php" ?>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>What The Fuck Should Lukas Have For Lunch</title>
    <link rel="shortcut icon" href="favicon.png">
    <link rel="stylesheet" href="css/style.css">

    <?php include_once "parts/meta.php" ?>
</head>
<body>
<?php include_once "parts/analytics.php" ?>

<section>
    <?php

    /**
     * Created by IntelliJ IDEA.
     * User: Lukas
     * Date: 15.05.2015
     * Time: 14:07
     */

    include_once "lib/api.php";

    $_menu = get_menu();
    echo get_content($_menu);
    echo get_content_footer($_menu);

    ?>

</section>

<?php include_once "parts/footer.php" ?>

</body>
</html>