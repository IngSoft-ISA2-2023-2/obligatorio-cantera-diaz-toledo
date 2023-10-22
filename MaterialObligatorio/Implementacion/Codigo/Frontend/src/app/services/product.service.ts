import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { CommonService } from "./CommonService";
import { Product, ProductRequest } from "../interfaces/product";
import { StorageManager } from '../utils/storage-manager';

@Injectable({ providedIn: "root" })
export class ProductService {

    private url = environment.apiUrl + "/api/product"; // environment.api.Url es la url de la api

    constructor(
        private http: HttpClient,
        private commonService: CommonService ,
        private storageManager: StorageManager
    ) { }

    getHttpHeaders(): HttpHeaders {
        let login = JSON.parse(this.storageManager.getLogin());
        let token = login ? login.token : "";
        
        return new HttpHeaders()
          .set('Content-Type', 'application/json')
          .set('Authorization', token);
      }

    /** POST Products from the server */
    createProduct(product: ProductRequest): Observable<Product> {
        return this.http.post<Product>(this.url, product, {headers: this.getHttpHeaders()}).pipe(
            tap(),
            catchError(this.handleError<Product>("Create Product"))
        );

    }

    deleteProduct(id: number): Observable<any> {
        const url = `${this.url}/${id}`;
        return this.http.delete<any>(url, {headers: this.getHttpHeaders() })
        .pipe(
          tap(),
          catchError(this.handleError<any>('Delete Product'))
        );
      }

      getProductByUser(): Observable<Product[]> {
        const url = `${this.url}/user`;
        return this.http.get<Product[]>(url, {headers: this.getHttpHeaders() })
          .pipe(
            tap(),
            catchError(this.handleError<Product[]>('Get Product By User', []))
          );
      }

      getProductById(id: number): Observable<Product> {
        const url = `${this.url}/${id}`;
        return this.http.get<Product>(url).pipe(
          tap(),
          catchError(this.handleError<Product>(`Get Invitation id=${id}`))
        );
      }

      updateProduct(id: number, product: ProductRequest): Observable<Product> {
        const url = `${this.url}/${id}`;
        return this.http.put<Product>(url, product, {headers: this.getHttpHeaders() }).pipe(
          tap(),
          catchError(this.handleError<Product>('Update Product'))
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