import { Injectable } from '@angular/core';

@Injectable()
export class ErrorService {
    public errormsg: string;
    public get hasError(): boolean {
        return this.errormsg != null;
    }
    public handleError(error) {
        this.errormsg = error.toString();
        console.log(this.errormsg);
    }
}