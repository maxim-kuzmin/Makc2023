@echo off

echo Migrations remove start

cd ..

dotnet ef migrations remove -- "Data Source=localhost;Initial Catalog=Sample;Integrated Security=False;User Id=sa;Password=Admin(2019);"

cd @

echo Migrations remove finish