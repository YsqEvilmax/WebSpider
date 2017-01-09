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
            .toPromise()
            .then(res => res.json() as T)
            .catch(this.handleError);
    }

    public post<T, P>(path: string, param: P) {
        let body = JSON.stringify(param);
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .post(path, body, options)
            .toPromise()
            .then(res => res.json() as T)
            .catch(this.handleError);
    }

    public put<T>(path: string, param: T) {
        let body = JSON.stringify(param);
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .put(path, body, options)
            .toPromise()
            .then(() => param)
            .catch(this.handleError);
    }

    public delete<T>(path:string) {
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .delete(path, options)
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        this.error.handleError(error.text());
        return Observable.throw(error.text() || 'Server error');
    }
}