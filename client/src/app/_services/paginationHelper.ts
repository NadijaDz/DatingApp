import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/operators";
import { PaginatedResult } from "../_models/pagination";

 export function  getPaginatedResult<T>(url, params, http: HttpClient){

    const paginatedResulet: PaginatedResult<T> = new PaginatedResult<T>();

    return http.get<T>(url , {observe: 'response', params}).pipe(
      map(response=>{
        paginatedResulet.result=response.body;
        if(response.headers.get('Pagination') !== null){
          paginatedResulet.pagination = JSON.parse(response.headers.get('Pagination'))
        }
        return paginatedResulet;
      })
    );
  }
 
export function  getPaginationHeaders(pageNumber: number, pageSize: number){
    let params = new HttpParams();

      params = params.append('pageNumber', pageNumber.toString());
      params = params.append('pageSize', pageSize.toString());

      return params;
  }

