# whatthefuckshouldlukashaveforlunch.com

Source-code of [whatthefuckshouldlukashaveforlunch.com](http://whatthefuckshouldlukashaveforlunch.com), written in some HTML, CSS & PHP.

It returns a random item of today's meal menu at the university canteen Regensburg.

## Execution

Make sure you have Docker installed and running!

Build it:

    docker build -t whatfuckinglunch .
    
Run it: 

    docker run -d -p 80:80 --name whatfuckinglunch whatfuckinglunch

Try it: You should now be able to view it by opening [localhost:80](http://localhost:80).