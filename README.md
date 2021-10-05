  &#xa0;

  <!-- <a href="https://desafio_cezar.netlify.app">Demo</a> -->
</div>

<h1 align="center">MINDMINERS 🧪</h1>

<p align="center">
  <img alt="Github top language" src="https://img.shields.io/github/languages/top/cpereira42/API42Labs?color=3de069">

  <img alt="Github language count" src="https://img.shields.io/github/languages/count/cpereira42/API42Labs?color=3de069">

  <img alt="Repository size" src="https://img.shields.io/github/repo-size/cpereira42/API42Labs?color=3de069">

</p>

<p align="center">
  <a href="#about">About</a> &#xa0; | &#xa0;
  <a href="#features">Features</a> &#xa0; | &#xa0;
  <a href="#libraries">Libraries</a> &#xa0; | &#xa0;
  <a href="#requirements">Requirements</a> &#xa0; | &#xa0;
  <a href="#starting">Starting</a> &#xa0; | &#xa0;
  <a href="#running">Running</a> &#xa0; | &#xa0;
  <a href="#testing">Testing</a> &#xa0; | &#xa0;
  <a href="#exiting">Exiting</a> &#xa0; | &#xa0;
  <a href="https://github.com/cpereira42" target="_blank">Author</a>
</p>

<br>

## About ##

## Features ##

The applications works with one or two parameters:
- one parameter: student's id<br>
returns the information about a student
- two parameters: student's id and specific information<br>
returns the basic information about a student and the specific information

## Libraries ##

The following libraries were used in this project:
- [curl](https://curl.se/)
- [mysql](https://dev.mysql.com/)
- [json-c](https://github.com/json-c/json-c)

## Requirements ##

Before starting, you need to have [Docker](https://docs.docker.com/get-docker/) installed.

## Starting ##

```bash
# Clone this project
$ git clone https://github.com/cpereira42/mindminers.git

# Go to the mindminers 
cd mindminers

# Go to the Program 
cd Program

```

## Running ##
```bash
# To compile
sudo dotnet run

# Please choose 1 to make a synchronization or 0 to exit
1
# Please choose the input file or 0 to exit:
../subtitle.srt

# Please choose the output file:
../new_subtitle.srt

# Please set signal + to increment or - to decrement
+

# Please set hour less/equal 23
5

# Please set minutes less/equal 59
10

# Please set seconds less/equal 59
10

# Please set milisseconds less/equal 999
100

# Press 1 to confirm or 0 to back menu
1

!! DONE

```

## Testing ##
```bash
# Go to Tests Folder
cd Tests

# Execute test
sudo dotnet test

```
&#xa0;

<a href="#top">Back to top</a>
