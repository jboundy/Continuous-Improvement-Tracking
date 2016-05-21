## ETL Tool - Excel to SQL ##

Below list the overall process and specifications to achieve with this tool

## Process ##
The use case is to migrate old data to a more usable back-end solution by running a ETL on Excel data.

Before starting, the user must verify configuration in Excel. The objective is to move all the content from excel to a SQL database and a table. The tables are created by naming the worksheet. For example, if your excel worksheet is named **Finance-Q1** then your table name will be **dbo.Finance-Q1**. Note that if you have more than one worksheet, that worksheet will create another table in your database.

Each row much contain a specified Data Type, otherwise the solution will determine its best guess. This can be done by right-clicking on a cell, choose format, and pick the category you want. This will determine the Data Type in SQL.

Once completed, given the UI, the user will give the database a name, then a path to the file located on their local machine. 

## Specs ##
The goal in code is to run this as a sequential process. Async may be a good choice, but not needed for now.
Once the excel file is loaded into the application, the solution needs to read and map the objects. The objects should be converted into a class object done by the business logic layer (note that this class file will not save to disk, just in memory during ETL). Once the class has been generated, Entity Framework will create a database based on user input. After database creation, the new class will become a dbcontext object and ready for migration. This is when the data in each row is then imported into the database. 
 
#### Things to consider ####
1. Develop a more friendly interface
2. Add more tests to the project and code coverage
	- Setup mocks and as well as integrations
3. Allow the user to choose their own data connector