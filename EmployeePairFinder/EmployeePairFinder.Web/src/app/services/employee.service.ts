import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import apiConfig from '../apiConfig.json';
import { EmployeePair } from '../models/employee-pair.model';

@Injectable()
export class EmployeeService {
  baseUrl = apiConfig.baseUrl;
  constructor(private httpClient: HttpClient) { }

  public $post(file: File): Observable<any> {
    let formData: FormData = new FormData();
    formData.append('csvFile', file as Blob);
    return this.httpClient.post(`${this.baseUrl}/api/Employee`, formData);
  }
}
