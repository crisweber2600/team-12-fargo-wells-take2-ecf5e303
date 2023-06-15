# Erin's a Java dev stubmling through.Net...but she's sure gonna try!
This is a very simple starter project to demonstrate SpecFlow and living-doc, as well as simple commands for C# outside of Visual Studio.
* "make bootstrap" will install the plugin necessary for SpecFlow results (only required if you are building locally)
* "make build" will clean and build this thing
* "make test" will run only unit tests 
* "make verify" will run and generate pretty output for SpecFlow tests in test-results folder
* "make run" will run the CLI
* Actions are configured to build and test on both main and develop
* Actions are configured to publish test results to gh-pages for your repo

NOTE: All specflow tests should have a tag of @acceptance to keep them properly segrated for the make file.

M1 MAC USERS: I had to force living doc to install with the correct architecture using -a arm64. I also had to manually set DOTNET_ROOT env var to the location of dotnet (which dotnet).

The CLI has been coded for you using a library called [Sharprompt][https://github.com/shibayan/Sharprompt], but it is bare-bones and filled with TODOs. You can find and edit the code in LevelUpGame/levelup/cli/Game.cs.  All the system operations are coded in LevelUpGame/levelup/GameController.cs. Other than CreateCharacter, which is implemented as an example of Cucumber testing, all the system operations are empty "do nothing" implementations.