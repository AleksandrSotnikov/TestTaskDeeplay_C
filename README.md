# TestTaskDeeplay_C

### Запуск программы:
1. Для использования программы необходимо установить дополнительное ПО: 
-- MSSQL Server для работы с БД;
 -- Visual Studio для компиляции;
2. Открыть решение "TestTaskDeeplay_C.sln"
3. Скомпилировать приложение;
4. Запустить;
> Если при запуске произошла ошибка подключения к базе данных требуется отредактировать файл "TestTaskDeeplay_C/appsettings.json", необходимо изменить параметр "MSSQL" на строку подключения к установленной на пк базе данных:
> "ConnectionStrings": {
			"MSSQL": "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestTask.db;Integrated Security=True"
		}