﻿import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { ErrorService } from './error.service';

@Injectable()
export class ApiService{
    public apiBase:string;
    constructor(private http: HttpService,
        private error: ErrorService) {
    }
    public create<T>(param: T) {
        return this.handleSubscribe<T>(
            this.http.post<T, T>(this.apiBase, param));
    }

    public createFrom<T, P>(param: P) {
        return this.handleSubscribe<T>(
            this.http.post<T, P>(this.apiBase, param));
    }

    public retrives<T>() {
        return this.handleSubscribe<T[]>(
            this.http.get<T[]>(this.apiBase));
    }

    public retrive<T>(id: number) {
        return this.handleSubscribe<T>(
            this.http.get<T>(`${this.apiBase}/${id}`));
    }

    public update<T>(id: number, param: T) {
        return this.handleSubscribe<T>(
            this.http.put<T>(`${this.apiBase}/${id}`, param));
    }

    public remove<T>(id: number) {
        return this.handleSubscribe<T>(
            this.http.delete<T>(`${this.apiBase}/${id}`));
    }

    private handleSubscribe<T>(fun) {
        let result: T = null;
        fun.subscribe(res => {
                result = res;
            }, err => this.error.handleError(err));
        return result;
    }
}