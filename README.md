﻿# Japan Language Course Web Site
---------------------------------------------------------------------------------------------
1. Установка
---------------------------------------------------------------------------------------------
Склонировать репозиторий:
>git clone https://github.com/Vinniko/JapanLanguage.git

Создать базу данных MySQL, например: 
>CREATE DATABASE MyDatabase;

Создать схему данных в новой базе данных: 
>mysql -u [user] -p [database_name] < ../JapanLanguageWebSiteDatabaseDump.sql

Настроить подключение к базе данных. Для этого необходимо перейти в папку ./TestWeb/Services/ 
и в файле DataBaseService в переменной DataBaseAdress указать данные для подключения к базе данных.

Пример:
<br>const String DataBaseAdress = "server=localhost;user=root;database=mydatabase;password=root;";

---------------------------------------------------------------------------------------------
2. Запуск
---------------------------------------------------------------------------------------------
Запуск в Microsoft VisualStudio: 
> Ctrl+F5

Для локальной публикации сервера, необходимо в Microsoft Visual Studio нажать на решение правой кнопкой мыши
и выбрать "Опубликовать" - "В локальной папке". После публикации в выбранной папке выполнить команду: 
> ./TestWeb.exe 

Сервер запустится на локальном хосте: http:/localhost:5000/

---------------------------------------------------------------------------------------------
3. Связь
---------------------------------------------------------------------------------------------

<br> Email: vinnik_21@bk.ru / vinniko333@gmail.com
<br> Telegram: https://t.me/vinnik0
<br> LinkedIn: https://www.linkedin.com/in/алексей-винник-7450a5208/
<br> HeadHunter: https://spb.hh.ru/resume/f658e91bff090474030039ed1f5a4141446844



