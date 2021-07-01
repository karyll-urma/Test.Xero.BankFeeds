Feature: AddBankAccountToOrganisation
	As a Xero User,
	In order to manage my business successfully,
	I want to be able to add an “ANZ (NZ)” bank account inside any Xero Organisation.
	https://login.xero.com/

Background:
	Given User navigate to application
	And User login using valid credentials

@Test
Scenario: S01_AddBankAccount_DiffOrganisation
	When User select '<Organisation>' as organisation
	And User add bank account with details below
		| Bank   | AccountName   | AccountType   | AccountNumber   | Currency   |
		| <Bank> | <AccountName> | <AccountType> | <AccountNumber> | <Currency> |
	Then User can see bank account was successfully added to oraganisation
	And User logout from the application

	Examples:
		| Organisation | Bank     | AccountName     | AccountType           | AccountNumber   | Currency                 |
		| TestOrg1     | ANZ (NZ) | RandomString-10 | Everyday (day-to-day) | RandomString-10 | NZD - New Zealand Dollar |
		| TestOrg2     | ANZ (NZ) | RandomString-10 | Everyday (day-to-day) | RandomString-10 | NZD - New Zealand Dollar |
		| TestOrg3     | ANZ (NZ) | RandomString-10 | Everyday (day-to-day) | RandomString-10 | NZD - New Zealand Dollar |

Scenario: S02_AddBankAccount_DiffAccountTypes
	When User select '<Organisation>' as organisation
	And User add bank account with details below
		| Bank   | AccountName   | AccountType   | AccountNumber   | Currency   |
		| <Bank> | <AccountName> | <AccountType> | <AccountNumber> | <Currency> |
	Then User can see bank account was successfully added to oraganisation
	And User logout from the application

	Examples:
		| Organisation | Bank     | AccountName     | AccountType           | AccountNumber   | Currency                 |
		| TestOrg1     | ANZ (NZ) | RandomString-10 | Everyday (day-to-day) | RandomString-10 | NZD - New Zealand Dollar |
		| TestOrg1     | ANZ (NZ) | RandomString-10 | Loan                  | RandomString-10 | NZD - New Zealand Dollar |
		| TestOrg1     | ANZ (NZ) | RandomString-10 | Term Deposit          | RandomString-10 | NZD - New Zealand Dollar |
		| TestOrg1     | ANZ (NZ) | RandomString-10 | Credit Card           | RandomString-4  | NZD - New Zealand Dollar |
		| TestOrg1     | ANZ (NZ) | RandomString-10 | Other                 | RandomString-10 | NZD - New Zealand Dollar |

