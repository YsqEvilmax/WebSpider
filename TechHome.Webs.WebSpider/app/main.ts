import {enableProdMode} from '@angular/core';
import {bootstrap}    from '@angular/platform-browser-dynamic'
import {AppServiceTodoList} from './services/app.service.todolist';
import {HTTP_PROVIDERS} from '@angular/http';
import { TodoListComponent } from './components/todolist/todolist.component';
import { WebSpiderComponent } from './components/webspider/web-spider.component';
import { ErrorService } from './services/error.service';
import { HttpService } from './services/http.service';
import { ApiService } from './services/api.service';

//enableProdMode();
//bootstrap(TodoListComponent, [HTTP_PROVIDERS, AppServiceTodoList]); 
bootstrap(WebSpiderComponent, [HTTP_PROVIDERS, ErrorService, HttpService, ApiService]); 