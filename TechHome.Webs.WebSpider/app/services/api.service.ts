import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpService } from './http.service';

@Injectable()
export class ApiService extends HttpService{
    public apiBase:string;
    constructor(http: Http) {
        super(http);
    }
    public create<T>(param: T) {
        return this.post<T, T>(this.apiBase, param);
    }

    public createFrom<T, P>(param: P) {
        return this.post<T, P>(this.apiBase, param);
    }

    public retrives<T>() {
        return this.get<T[]>(this.apiBase);
    }

    public retrive<T>(id: number) {
        return this.get<T>(`${this.apiBase}/${id}`);
    }

    public update<T>(id:number, param: T) {
        return this.put<T>(`${this.apiBase}/${id}`, param);
    }

    public remove<T>(id: number){
        return this.delete<T>(`${this.apiBase}/${id}`);
    }
}