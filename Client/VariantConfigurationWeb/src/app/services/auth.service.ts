import { Http, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

import { RegisterModel } from '../models/register.model';
import { LoginModel } from '../models/login.model';
import { ResetPasswordModel } from '../models/reset-password.model';
import { ForgotPasswordModel } from '../models/forgot-password.model';
import { Host } from '../helpers/host.helper';

@Injectable()
export class AuthService extends Host {
    REGISTER_ENDPOINT = this.host + 'api/account/register';
    CONFIRM_EMAIL_ENDPOINT = this.host + 'api/account/confirmemail';
    TOKEN_ENDPOINT = this.host + 'token';
    FORGOT_PASSWORD_ENDPOINT = this.host + 'api/account/forgotpassword';
    RESETT_PASSWORD_ENDPOINT = this.host + 'api/account/resetpassword';

    constructor(private http: Http) {
        super();
    }

    public createHeaders(): Headers {
        const headers = new Headers();
        headers.append('Authorization', 'Bearer ' + this.getToken());
        return headers;
       }
    register(body: RegisterModel) {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        const options = new RequestOptions({ headers: headers});

        return this.http.post(this.REGISTER_ENDPOINT, body, options);
    }

    confirmEmail(userId: string, code: string) {
        return this.http.get(this.CONFIRM_EMAIL_ENDPOINT,
        {
            params: {
                userId: userId,
                code: code
            }
        });
    }

    login(body: string) {
        const headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        const options = new RequestOptions({ headers: headers});

        return this.http.post(this.TOKEN_ENDPOINT, body, options)
            .map((res) => {
                const response = res.json();
                this.setToken(response.access_token);
                this.setUser(response.userName);
            }
        );
    }

    logout() {
        localStorage.clear();
    }

    forgotPassword(body: ForgotPasswordModel) {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        const options = new RequestOptions({ headers: headers});
        return this.http.post(this.FORGOT_PASSWORD_ENDPOINT, body, options);
    }

    resetPassword(body: ResetPasswordModel) {
        return this.http.post(this.RESETT_PASSWORD_ENDPOINT, body);
    }

    isLoggedIn(): boolean {
        return !!localStorage.getItem('token');
    }

    private setToken(token: string) {
        localStorage.setItem('token', token);
    }

    private getToken() {
        return localStorage.getItem('token');
    }

    private setUser(userName: string) {
        localStorage.setItem('userName', userName);
    }
}
