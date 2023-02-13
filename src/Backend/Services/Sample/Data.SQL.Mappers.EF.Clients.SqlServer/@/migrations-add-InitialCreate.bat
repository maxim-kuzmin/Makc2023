@echo off

echo Migrations add InitialCreate start

cd ..

dotnet ef migrations add InitialCreate -- "Data Source=localhost;Initial Catalog=Sample;Integrated Security=False;User Id=sa;Password=Admin(2019);"

cd @

echo Migrations add InitialCreate finish