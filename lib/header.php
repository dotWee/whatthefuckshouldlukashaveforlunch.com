<?php
/**
 * Created by IntelliJ IDEA.
 * User: lukas
 * Date: 24.02.17
 * Time: 20:15
 */

// Set timezone
date_default_timezone_set('Europe/Berlin');

// Disable cache using custom header
header("Cache-Control: no-store, no-cache, must-revalidate, max-age=0");
header("Cache-Control: post-check=0, pre-check=0", false);
header("Pragma: no-cache");