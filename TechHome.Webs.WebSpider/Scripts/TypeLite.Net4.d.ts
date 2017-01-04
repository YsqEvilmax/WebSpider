﻿
 
 
 

 

/// <reference path="Enums.ts" />

declare module Models {
	interface List {
		Count: number;
		CountEnded: number;
		Id: number;
		Name: string;
		Tasks: Models.Task[];
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
declare module Models.ViewModel {
	interface JSONReturnVM<T> {
		element: T;
		errormessage: string;
		haserror: boolean;
	}
}
declare module TechHome.Services.Tasks {
	interface ITask {
		Comment: string;
		FileName: string;
		FolderPath: string;
		State: TechHome.Services.Tasks.State;
		Uri: string;
	}
}


