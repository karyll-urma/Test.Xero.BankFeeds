# Xero - BankFeeds AddBankAccount

## Project Description
This solution will test the existing functionality of Xero - Accounting - Add bank account. This aims to benefit the testers/team in terms of execution time, accuracy and reducing manual effort.

## Build Status
Repository is currently at GitHub https://github.com/karyll-urma/Test.Xero.BankFeeds

[![Xero Bank Feeds](https://github.com/karyll-urma/Test.Xero.BankFeeds/actions/workflows/dotnet.yml/badge.svg)](https://github.com/karyll-urma/Test.Xero.BankFeeds/actions/workflows/dotnet.yml)
Build status is currently passing. 

## Application under test

https://login.xero.com/
 
## Technology/Framework

Framework: .Net 5.0

Test Framework: NUnit

Model: Behavioral Driven Development ? Specflow

Tools: Visual Studio C# 

## Tests
Current Test status:

Feature files: 1

Number of test cases: 8

Passed: 8

Failed: 0


## How to use
Step 1: Go to github repository link and clone 

Step 2: Open solution: Testing.Xero.BankFeeds.sln

Step 3 : Setup runsettings file
Go to Test>Configure Run Setting>Select Solution Wide runsettings File
and
Select Settings.runsettings
*Framework global data is avaialabe in Settings.runsettings file. These includes browser(default to Chrome), implicitwait, url and user credentials.

Step 4: Clean and Build the solution

Step 5: All set to run scripts.

Step 6: After executing,extent report will be created on your local temp folder
C:\Temp\Test Reports