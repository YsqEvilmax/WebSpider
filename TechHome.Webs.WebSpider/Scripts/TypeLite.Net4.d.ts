﻿
 
 
 

 

/// <reference path="Enums.ts" />

declare module TechHome.Services.Tasks {
	interface ITask {
		Comment: string;
		FileName: string;
		FolderPath: string;
		State: TechHome.Services.Tasks.State;
		Uri: string;
	}
}
declare module TechHome.Webs.WebSpider.Models {
	interface List {
		Count: number;
		CountEnded: number;
		Id: number;
		Name: string;
		Tasks: TechHome.Webs.WebSpider.Models.Task[];
	}
	interface Task {
		Ended: boolean;
		Id: number;
		ListId: number;
		Name: string;
	}
	interface WebTask {
		Template: string;
		Url: string;
	}
}


