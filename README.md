# GamesRateSln

## Stack 
* .NET CORE MVC
* AutoMapper
* Entitty Framework
* StyleCop
* Newtonsoft.Json
* jQuery
* DataTables
* ChartJS
* NSwag

## Possible improvements
* Rework DataTable paging/search functionality to use backend code or use another more actual library 
* Rework UI validation. Currently implented only standard browser validation.
* Rework backend validation. Currently implented only standard MVC validation. Maybe better use Fluent Validation.
* Rework exception handling on backend. At this moment has been implemented standard MVC handler with standard logging.
* * As good approach all logs should be seved to the outside of the system.
* * Add performance monitor like Azure Application Insights  
* Add ui exception handeling
* Review or rework statistic methodes to make they more accurate
* Add Unit test and UI test

## External API
To the project added third party Api client to add initial data (https://api.rawg.io/api/games). Client models and methods autmaticaly genrated via the NSwag.


