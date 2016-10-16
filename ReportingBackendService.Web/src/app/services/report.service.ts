import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Report } from "../models";
import { Observable } from "rxjs";

import { apiCofiguration } from "../configuration";


@Injectable()
export class ReportService {
    constructor(private _http: Http) { }

    public add(entity: Report) {
        return this._http
            .post(`${apiCofiguration.baseUrl}/api/report/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/report/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${apiCofiguration.baseUrl}/api/report/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${apiCofiguration.baseUrl}/api/report/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get baseUrl() { return apiCofiguration.baseUrl; }

}
