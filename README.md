<!--
    Entity Data Model состоит из трех уровней:
    Концептуальный уровень - определение классов
    сущностей, используемых в приложении.

    Уровень хранилища - определяет таблицы, столбцы,
    отношения между таблицами и типы данных, с
    которыми сопоставляется используемая база данных.
    
    Уровень сопоставления (маппинга) - служит
    посредником между предыдущими двумя, определяя
    сопоставление между свойствами класса сущности и
    столбцами таблиц. 
-->
## Перед запуском MVC PROJECT
> Требуется установка СУБД [PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads), небольшой [гайд по установке от команды Yandex Practicum](https://practicum.yandex.ru/blog/chto-takoe-subd-postgresql/#ustanovka)
![Разработка на базе СУБД PostgreSQL](/data/pgs.png)

## Настройка окружения проекта
| Команда | Описание |
| ----- | ----- |
| `dotnet new mvc` | Создание структуры проекта ASP.NET Core MVC (Model, View, Controller) |
| `dotnet add package Microsoft.EntityFrameworkCore` | Добавление в проект пакета EntityFramework |
| `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL` | Добавление в проект пакета для поддержки работы с БД PostgreSQL |
| `dotnet run` | Запуск приложения |


