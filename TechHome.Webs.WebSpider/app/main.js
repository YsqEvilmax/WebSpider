"use strict";
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var http_1 = require('@angular/http');
var web_spider_component_1 = require('./components/webspider/web-spider.component');
var error_service_1 = require('./services/error.service');
var http_service_1 = require('./services/http.service');
var api_service_1 = require('./services/api.service');
//enableProdMode();
//bootstrap(TodoListComponent, [HTTP_PROVIDERS, AppServiceTodoList]); 
platform_browser_dynamic_1.bootstrap(web_spider_component_1.WebSpiderComponent, [http_1.HTTP_PROVIDERS, error_service_1.ErrorService, http_service_1.HttpService, api_service_1.ApiService]);
//# sourceMappingURL=main.js.map