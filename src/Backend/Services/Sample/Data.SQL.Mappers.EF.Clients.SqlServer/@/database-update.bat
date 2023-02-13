@echo off

echo Database update start

cd ..

dotnet ef database update -- "Data Source=localhost;Initial Catalog=Sample;Integrated Security=False;User Id=sa;Password=Admin(2019);"

cd @

echo Database update finish