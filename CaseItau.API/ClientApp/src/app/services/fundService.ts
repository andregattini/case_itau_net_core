import { ErrorHandler, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Fund } from '../models/fund';
import { FundType } from '../models/fund-type';

@Injectable({
  providedIn: 'root'
})

export class FundService {
  private url: string = '';
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-type': 'application/json' })
  }

  getFunds(): Observable<Fund[]> {
    return this.httpClient.get<Fund[]>(this.url+'api/fund')
        .pipe(
              retry(2),
            catchError(this.handleError)
            )
  }

  getFundByCode(code: string): Observable<Fund> {
    return this.httpClient.get<Fund>(this.url + 'api/fund/' + code)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  createFund(fund: Fund): Observable<Fund> {
    return this.httpClient.post<Fund>(this.url+'api/fund', JSON.stringify(fund), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  updateFund(fund: Fund): Observable<Fund> {
    return this.httpClient.put<Fund>(this.url + 'api/fund/' + fund.code, JSON.stringify(fund), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  updateFundPatrimony(fund: Fund): Observable<Fund> {
    return this.httpClient.patch<Fund>(this.url + 'api/fund/' + fund.code + '/patrimony', JSON.stringify(fund.patrimony), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }
  deleteFund(code: string): Observable<Fund> {
    return this.httpClient.delete<Fund>(this.url + 'api/fund/' + code)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
