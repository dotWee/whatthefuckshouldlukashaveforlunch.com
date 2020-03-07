# [whatthefuckshouldlukashaveforlunch](http://heroku.whatthefuckshouldlukashaveforlunch.com/)

[![GitHub License](https://img.shields.io/github/license/dotWee/startpage)](https://github.com/dotWee/whatthefuckshouldlukashaveforlunch.com/blob/master/LICENSE)

_what the fuck should lukas have for lunch*?_

<sub>* at the regensburg university of applied sciences canteen </sub>

this repository contains the source code of [whatthefuckshouldlukashaveforlunch](http://heroku.whatthefuckshouldlukashaveforlunch.com/), written in some `c#` using the `.net core 3` framework.

> **anecdote**: this code exists since i started programming. developed with absolutly zero knowledge. i'll probably never touch this code again.

> **recruters**: please don't look

## [setup](#setup)

1. get the [.net core 3.1 sdk](https://dotnet.microsoft.com/download/) for your platform

2. clone this git repository and change into the repo directory:

    ```bash
    $ git clone https://github.com/dotWee/whatthefuckshouldlukashaveforlunch.com

    $ cd whatthefuckshouldlukashaveforlunch.com
    ```

## [usage](#usage)

### run site locally

1. pull required package dependencies:

    ```bash
    $ dotnet restore
    ```

2. start building & run on localhost:

    ```bash
    $ dotnet run
    info: Microsoft.Hosting.Lifetime[0]
          Now listening on: http://localhost:5000
    info: Microsoft.Hosting.Lifetime[0]
          Application started. Press Ctrl+C to shut down.
    ```

3. now browse to [localhost:5000](http://localhost:5000)

### run using a self-made docker [docker](https://www.docker.com/) image

1. build the docker image:

    ```bash
    $ docker build \
        --pull --rm \
        -t whatthefuckshouldlukashaveforlunch .
    ```

2. and run the fresh docker image:

    ```bash
    $ docker run \
        --rm -it \
        -p 8080:80 \
        whatthefuckshouldlukashaveforlunch
    ```

3. now browse to [localhost:8080](http://localhost:8080)

### or pull the [docker](https://www.docker.com/) image from the docker hub

1. pull the docker image:

    ```bash
    $ docker pull dotwee/whatthefuckshouldlukashaveforlunch
    ```

2. and run the docker image:

    ```bash
    $ docker run \
        --rm -it \
        -p 8080:80 \
        dotwee/whatthefuckshouldlukashaveforlunch
    ```

3. now browse to [localhost:8080](http://localhost:8080)

## [license](#license)

copyright (c) 2019 lukas 'dotwee' wolfsteiner <lukas@wolfsteiner.media>

licensed under the [_do what the fuck you want to_](/LICENSE) public license