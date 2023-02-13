@echo off

echo Database update InitialCreate start

cd ..

dotnet ef database update InitialCreate -- "Data Source=localhost;Initial Catalog=Sample;Integrated Security=False;User Id=sa;Password=Admin(2019);"

cd @

echo Database update InitialCreate finish