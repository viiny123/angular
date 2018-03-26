import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

import { Service } from 'app/core/service-helper/service';

@Injectable()
export class HttpBaseService {
    private baseurl = Service.API_ENDPOINT;

    constructor(private http: Http) { }

    public post(url: any, obj: any) {
        const headers = new Headers();
        const options = new RequestOptions({ headers: headers });

        return this.http.post(url, obj, options).map(res => res.json());
    }

    public get(url: any, id: any = null) {
        const headers = new Headers();
        const options = new RequestOptions({ headers: headers });
        if (id != null && id !== undefined && id !== '') {
            url = url + '/' + id;
        }
        return this.http.get(url, options).map(res => res.json());
    }

    public put(url: any, obj: any) {
        const headers = new Headers();
        const options = new RequestOptions({ headers: headers });
        return this.http.put(url, obj, options).map(res => res.json());
    }

    public delete(url: any, id: any = null) {
        const headers = new Headers();
        const options = new RequestOptions({ headers: headers });

        let paramId = '';
        if (id) {
            paramId = `/${id}`;
        }

        return this.http.delete(`${url}${paramId}`, options).map(res => res.json());
    }
}
