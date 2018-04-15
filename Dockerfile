FROM php:7.0-apache
COPY css/ /var/www/html/css/
COPY lib/ /var/www/html/lib/
COPY parts/ /var/www/html/parts/
COPY index.php /var/www/html/
COPY favicon.png /var/www/html/
