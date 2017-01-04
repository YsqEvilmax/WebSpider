import { Component, OnInit } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { ApiService } from "../../services/api.service";
import ITask = TechHome.Services.Tasks.ITask;

@Component({
  selector: 'web-spider',
  templateUrl: './web-spider.component.html',
  styleUrls: ['./web-spider.component.css']
})
export class WebSpiderComponent implements OnInit {
    tasks: Models.WebTask[];
  results: ITask[];
  constructor(private api:ApiService) { }

  ngOnInit() {
      this.tasks = [
          {
              Url: "http://t66y.com/htm_data/22/1612/2196077.html",
              Template: "CLPage.xml"
          }
      ];
      this.api.apiBase = 'http://localhost:61797/api/WebTasks';
  }

  GetResults() {
      this.api.createFrom<ITask[], Models.WebTask[]>(this.tasks).then((res) => {
          this.results = res;
      });
  }
}
