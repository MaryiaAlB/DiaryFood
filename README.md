DiaryFood.API

Учебный проект: REST API для дневника питания на ASP.NET Core (.NET 10).

Стек
* C# / ASP.NET Core Web API
* Swagger (OpenAPI)
* Архитектура: Контроллеры, DTO, Сервисы

Запуск
1. `dotnet run` в папке проекта
2. Открыть `http://localhost:<порт>/swagger`

Эндпоинты
Продукты (`/api/product`):
* `GET /` — все продукты
* `GET /{id}` — продукт по ID
* `POST /` — создать
* `PUT /{id}` — обновить
* `DELETE /{id}` — удалить

Калькулятор (`/api/calculate`):
* `GET /` — расчет КБЖУ по параметрам (вес, рост, возраст и т.д.)

Планы
- [ ] Подключение EF Core и SQL Server
- [ ] CRUD для рецептов и дневника
- [ ] Внедрение Dependency Injection
