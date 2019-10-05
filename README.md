# Code-Lines
Simple executable for windows to calculate how many lines of code are in a directory.

## Usage
1. Build project in Visual Studio or otherwise
1. Add path to exe in your Environment variables
1. From the command line, run `code-lines -c` to analyse current working directory

Alternatively: run `code-lines <path>` to specify a path. If path has spaces, surround it with quotation marks.

Example: `code-lines "C:\Users\<Your username>\Desktop\Folder with spaces\"`

## Output
![Output](https://i.imgur.com/aQmKJfF.png)

## Supported languages
* C#
* C
* C++
* Java
* JavaScript
* Python

### Note
Program will print out a line of analysis for every language that it found in its search
