import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import { ErrorService } from './error.service';

@Injectable()
export class HttpService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http,
        private error: ErrorService) {
    }

    public get<T>(path: string){
        return this.http
            .get(path)
            .map(res => res.json().data as T)
            .catch(this.handleError) as Observable<T>;
    }

    public post<T, P>(path: string, param: P) {
        let body = JSON.stringify(param);
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .post(path, body, options)
            .map(res => res.json().data as T)
            .catch(this.handleError) as Observable<T>;
    }

    public put<T>(path: string, param: T) {
        let body = JSON.stringify(param);
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .put(path, body, options)
            .map(() => param)
            .catch(this.handleError) as Observable<T>;
    }

    public delete<T>(path:string) {
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .delete(path, options)
            .map(() => null)
            .catch(this.handleError) as Observable<T>;
    }

    private handleError(error: Response) {
        this.error.handleError(error.text());
        return Observable.throw(error.text() || 'Server error');
    }
}