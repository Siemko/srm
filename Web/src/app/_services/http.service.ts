import { Router } from '@angular/router';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { LoginService } from '../login/login.service';
import { ToastrService } from 'ngx-toastr';
declare var $: any;

@Injectable()
export class HttpService {

    constructor(private http: Http,
        private router: Router, private toastr: ToastrService) {
    }

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.http
            .get(HttpService.prepareUrl(url), this.setHeaders(options))
            .catch(this.catchError());
    }

    post(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        return this.http
            .post(HttpService.prepareUrl(url), body, this.setHeaders(options))
            .catch(this.catchError());
    }

    put(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        return this.http
            .put(HttpService.prepareUrl(url), body, this.setHeaders(options))
            .catch(this.catchError());
    }

    path(url: string, body: any, options?: RequestOptions): Observable<Response> {
        return this.http
            .patch(HttpService.prepareUrl(url), body, this.setHeaders(options))
            .catch(this.catchError())
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.http
            .delete(HttpService.prepareUrl(url), this.setHeaders(options))
            .catch(this.catchError());
    }

    setHeaders(options: RequestOptionsArgs): RequestOptionsArgs {
        if (!options) { options = { headers: new Headers() }; }

        if (!options) {
            options = { headers: new Headers() };
        }

        if (!options.headers) {
            options.headers = new Headers();
        }

        options.headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
        return options;
    }

    static prepareUrl(url: string): string {
        if (window.location.hostname === 'localhost' && window.location.port === '4200') {
            return `http://localhost:5999/${url}`;
        }
        return url;
    }

    private catchError() {
        return (res: Response) => {
            if (!res.ok) { this.toastr.error(`${res.json().message}`); }
            if (res.status === 401) {
                localStorage.removeItem('token');
                this.router.navigate(['/login']);
                return;
            }

            let msg;
            try {
                msg = res.json().message;
            } catch (e) {
                msg = res.text();
            }

            console.info("Error Response", res);
            if (res.status === 401 || res.status === 403) {
                this.router.navigate(['/login']);
            }

            return Observable.throw(res);
        };
    }
}
