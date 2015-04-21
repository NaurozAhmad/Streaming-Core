Key Requirements
	I installed the following packages for creating database. But I don't know which one of these two actually worked.
	MySQL Connector/Net (http://dev.mysql.com/downloads/connector/net): A library that is used for connecting to MySQL using C#.
	mysql-for-visualstudio-1.2.3.msi

	After installation I went to "Solution Explorer" > References. Right click and add reference. Look for MySQL.Data (Due to installing two packages, or maybe three, I had 3 MySQL.DATA with different versions. I selected the latest.).
	That's it. Look at the code for the rest.