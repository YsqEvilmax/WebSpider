import { Component, OnInit } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { ApiService } from "../../services/api.service";

@Component({
  selector: 'web-spider',
  templateUrl: './web-spider.component.html',
  styleUrls: ['./web-spider.component.css']
})
export class WebSpiderComponent implements OnInit {
  //  tasks: TechHome.Webs.WebSpider.Models.WebTask;
  //results: TechHome.Services.Tasks.ITask[];
  //constructor(private api:ApiService) { }

  ngOnInit() {
      //this.tasks = [
      //    {
      //        url: "http://t66y.com/htm_data/22/1612/2196077.html",
      //        template: "CLPage.xml"
      //    }
      //];
      //this.api.apiBase = 'http://localhost:61797/api/WebTasks';
  }

  //GetResults() {
  //    this.results = this.api.createFrom<ITask[], WebTask[]>(this.tasks);
  //}
}
