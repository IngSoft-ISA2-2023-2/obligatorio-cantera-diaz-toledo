import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { CommonService } from "./CommonService";
import { Product } from "../interfaces/product";

@Injectable({ providedIn: "root" })
export class ProductService {

    private url = environment.apiUrl + "/api/products"; // environment.api.Url es la url de la api

    constructor(
        private http: HttpClient,
        private commonService: CommonService 
    ) { }

    /** POST Products from the server */
    createProduct(product: Product): Observable<Product> {
        return this.http.post<Product>(this.url, product).pipe(
            tap(),
            catchError(this.handleError<Product>("Create Product"))
        );

    }

    /**
     * Handle Http operation that failed.
     * Let the app continue.
     *
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
    private handleError<T>(operation = "operation", result?: T) {
        return (error: any): Observable<T> => {

            this.log(`${operation} failed: ${error.error.message}`);

            return of(result as T);

        };
    }

    /** Log a ProductService error with the MessageService */
    private log(message: string) {
        this.commonService.updateToastData(message, "danger", "Error");
    }

}